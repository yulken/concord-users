using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Infra.Persistence.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            UserModel? model = _dbContext.Users.SingleOrDefault(user => user.Id == id && user.IsActive());
            if (model == null) { 
                return null; 
            }
            return Map(model);
        }


        public User? FindByUuid(string uuid)
        {
            UserModel? model = _dbContext.Users.SingleOrDefault(u => u.Uuid == uuid 
                && u.Status == UserStatusConverter.GetShortValue(UserStatus.Active));
            if (model == null)
            {
                return null;
            }
            return Map(model);
        }

        public User? FindByEmailOrLogin(string email, string login)
        {
            UserModel? model = _dbContext.Users.SingleOrDefault(u => (u.Email == email || u.Login == login) 
                && u.Status == UserStatusConverter.GetShortValue(UserStatus.Active));
            if (model == null)
            {
                return null;
            }
            return Map(model);
        }

        public List<User> FindAll()
        {
            //_dbContext.Users.ToList())
            List<UserModel> users = [.. _dbContext.Users];
            return _mapper.Map<List<UserModel>,List<User>>(users);
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
                && u.Status == UserStatusConverter.GetShortValue(UserStatus.Active));
            if (oldModel == null)
            {
                return null;
            }
            UserModel newModel = _mapper.Map(updatedProps, oldModel);

            _dbContext.SaveChanges();
            return Map(newModel);
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
            return user.Status == UserStatusConverter.GetShortValue(UserStatus.Active);
        }
    }
}
