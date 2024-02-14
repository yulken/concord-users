using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Domain.Ports;
using concord_users.Infra.Data.Models;
using concord_users.Infra.Data.Repositories;

namespace concord_users.Infra.Data.Adapters
{
    public class CreateUserAdapter(
        UserRepository repository,
        IMapper mapper
        ) : ICreateUserPort
    {
        private readonly UserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public User Execute(User user)
        {
            UserModel userModel = _mapper.Map<UserModel>(user);
            userModel.Uuid = Guid.NewGuid().ToString();
            UserModel createdUserModel = _repository.Create(userModel);
            return _mapper.Map<User>(createdUserModel);
        }
    }
}
