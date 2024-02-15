using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases.Input;
using concord_users.Src.Infra.Data.Models;
using concord_users.Src.Infra.Http.Dtos;

namespace concord_users.Src.Mappers
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
