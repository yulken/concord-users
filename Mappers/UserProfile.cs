using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Domain.UseCases.Input;
using concord_users.Infra.Data.Models;
using concord_users.Infra.Http.Dtos;

namespace concord_users.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestDTO, CreateUserInput>();
            CreateMap<CreateUserInput, User>()
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePicture));
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
        }
    }
}
