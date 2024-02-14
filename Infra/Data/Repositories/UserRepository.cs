using AutoMapper;
using concord_users.Infra.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace concord_users.Infra.Data.Repositories
{
    public class UserRepository(
        AppDbContext appDbContext,
        IMapper mapper
        ) 
    {
        private readonly AppDbContext _dbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public UserModel? FindById(long id)
        {
            return _dbContext.Find<UserModel>(id);
        }

        public List<UserModel> FindAll()
        {
            //_dbContext.Users.ToList())
            return [.. _dbContext.Users];
        }

        public UserModel Create(UserModel userModel)
        {
            EntityEntry<UserModel> entry = _dbContext.Users.Add(userModel);
            _dbContext.SaveChanges();
            return entry.Entity;
        }
    }
}
