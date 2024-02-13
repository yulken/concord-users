using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Infra.Data.Models;

namespace concord_users.Infra.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
        }
    }
}
