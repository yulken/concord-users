using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Domain.Ports;
using concord_users.Infra.Data.Models;
using concord_users.Infra.Data.Repositories;

namespace concord_users.Infra.Data.Adapters
{
    public class ListUserAdapter(
        UserRepository repository,
        IMapper mapper
        ) : IListUserPort
    {
        private readonly UserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<User> Execute()
        {           
            return _mapper.Map<List<UserModel>, List<User>>(_repository.FindAll());
        }
    }
}
