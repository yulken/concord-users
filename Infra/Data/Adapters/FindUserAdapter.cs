using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Domain.Ports;
using concord_users.Infra.Data.Models;
using concord_users.Infra.Data.Repositories;

namespace concord_users.Infra.Data.Adapters
{
    public class FindUserAdapter(
        UserRepository repository,
        IMapper mapper
        ) :IFindUserPort
    {
        private readonly UserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public User? Execute(long id)
        {
            UserModel? model = _repository.FindById(id);
            if (model == null) { 
                return null; 
            }

            return _mapper.Map<User>(model);
        } 
    }
}
