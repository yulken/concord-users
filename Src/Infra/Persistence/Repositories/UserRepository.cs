using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Input;
using concord_users.Src.Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

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
                .Where(el => el.Status == UserStatusUtil.GetShortValue(UserStatus.Active) && 
                ((input.Uuid == null && input.Email == null && input.Login == null) || (
                    (input.Uuid != null && el.Uuid.Equals(input.Uuid)) || 
                    (input.Email != null && el.Email.Contains(input.Email)) || 
                    (input.Login != null && el.Login.Contains(input.Login)))))
                .Skip(pagination.PageSize * pagination.PageCount)
                .Take(pagination.PageSize)
                
            ];

            List<UserModel> sortedUsers = (OrderByEnum.Desc.Equals(pagination.OrderBy)) 
                ? [.. users.OrderByDescending(el => el.Id)]
                : [.. users.OrderBy(el => el.Id)];

            return _mapper.Map<List<UserModel>,List<User>>(sortedUsers);
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

        private User Map(UserModel user)
        {
            return _mapper.Map<User>(user);
        }

        private static bool IsActive(UserModel user)
        {
            return user.Status == UserStatusUtil.GetShortValue(UserStatus.Active);
        }

    }
}
