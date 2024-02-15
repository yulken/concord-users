using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Infra.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace concord_users.Src.Infra.Data.Repositories
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
            UserModel? model = _dbContext.Find<UserModel>(id);
            if (model == null) { 
                return null; 
            }
            return _mapper.Map<User>(model);
        }

        public User? FindByEmailOrLogin(string email, string login)
        {
            UserModel? model = _dbContext.Users.Single(user => user.Email == email || user.Login == login);
            if (model == null)
            {
                return null;
            }
            return _mapper.Map<User>(model);
        }

        public List<User> FindAll()
        {
            //_dbContext.Users.ToList())
            List<UserModel> users = [.. _dbContext.Users];
            return _mapper.Map<List<UserModel>,List<User>>(users);
        }

        public User Create(User user)
        {
            UserModel userModel = _mapper.Map<UserModel>(user);
            EntityEntry<UserModel> entry = _dbContext.Users.Add(userModel);
            _dbContext.SaveChanges();
            return _mapper.Map<User>(entry.Entity);
        }
    }
}
