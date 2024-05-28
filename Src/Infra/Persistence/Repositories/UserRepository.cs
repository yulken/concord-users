using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Input;
using concord_users.Src.Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace concord_users.Src.Infra.Persistence.Repositories
{
    public class UserRepository(
        AppDbContext appDbContext,
        IMapper mapper
        ): IUserPersistencePort
    {
        private readonly AppDbContext _dbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public User? FindById(long id)
        {
            UserModel? model = _dbContext.Users
                .SingleOrDefault(user => user.Id == id && user.IsActive());
            if (model == null) { 
                return null; 
            }
            return Map(model);
        }


        public User? FindByUuid(string uuid)
        {
            UserModel? model = _dbContext.Users
                .SingleOrDefault(u => u.Uuid == uuid 
                && u.Status == UserStatusUtil.GetShortValue(UserStatus.Active));
            if (model == null)
            {
                return null;
            }
            return Map(model);
        }

        public User? FindByEmailOrLogin(string email, string login)
        {
            UserModel? model = _dbContext.Users
                .SingleOrDefault(u => (u.Email == email || u.Login == login) 
                && u.Status == UserStatusUtil.GetShortValue(UserStatus.Active));
            if (model == null)
            {
                return null;
            }
            return Map(model);
        }

        public List<User> FindAll(FindUsersInput input, Pagination pagination)
        {
            List<UserModel> users =
            [
                .. _dbContext.Users
                .Where(FilterUsers(input))
                .Skip(pagination.PageSize * pagination.PageCount)
                .Take(pagination.PageSize)
                
            ];

            List<UserModel> sortedUsers = (OrderByEnum.Desc.Equals(pagination.OrderBy)) 
                ? [.. users.OrderByDescending(el => el.Id)]
                : [.. users.OrderBy(el => el.Id)];

            return sortedUsers.Select(Map).ToList();
        }

        public User Create(User user)
        {
            UserModel userModel = Map(user);
            EntityEntry<UserModel> entry = _dbContext.Users.Add(userModel);
            _dbContext.SaveChanges();
            return Map(entry.Entity);
        }

        public User? Update(string uuid, User updatedProps)
        {
            UserModel? oldModel = _dbContext.Users.SingleOrDefault(u => u.Uuid == uuid 
                && u.Status == UserStatusUtil.GetShortValue(UserStatus.Active));
            if (oldModel == null)
            {
                return null;
            }
            UserModel newModel = _mapper.Map(updatedProps, oldModel);

            _dbContext.SaveChanges();
            return Map(newModel);
        }

        public User? FindWithLoginAndPasword(string login, string password)
        {
            UserModel? model = _dbContext.Users.SingleOrDefault(u => u.Login == login
               && u.Password == password);
            if (model == null)
            {
                return null;
            }
            return Map(model);
        }

        private UserModel Map(User user)
        {
            return _mapper.Map<UserModel>(user);
        }

        private static Expression<Func<UserModel, bool>> FilterUsers(FindUsersInput input)
        {
            return model => model.Status == UserStatusUtil.GetShortValue(UserStatus.Active) &&
                ((input.ExceptUuid == null && input.Uuid == null && input.Email == null && input.Login == null) || (
                    (input.Uuid != null && model.Uuid.Equals(input.Uuid)) ||
                    (input.ExceptUuid != null && !model.Uuid.Equals(input.ExceptUuid)) ||
                    (input.Email != null && model.Email.Contains(input.Email)) ||
                    (input.Login != null && model.Login.Contains(input.Login))));
        }

        private static User Map(UserModel user)
        {
            return new User(
                user.Uuid,
                user.Name,
                user.Email,
                user.Login,
                user.Password,
                user.Status,
                user.ProfilePictureUrl
                );
        }

        private static bool IsActive(UserModel user)
        {
            return user.Status == UserStatusUtil.GetShortValue(UserStatus.Active);
        }

    }
}
