using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Domain.Ports;
using concord_users.Infra.Data.Models;

namespace concord_users.Infra.Data.Repositories
{
    public class UserRepository(
        AppDbContext appDbContext,
        IMapper mapper
        ) : IUserDataPort
    {
        private readonly AppDbContext _dbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public User FindById(long id)
        {
            return _mapper.Map<User>(_dbContext.Find<UserModel>(id));
        }

        public List<User> FindAll()
        {
            return _mapper.Map<List<UserModel>, List<User>>(_dbContext.Users.ToList());
        }
    }
}
