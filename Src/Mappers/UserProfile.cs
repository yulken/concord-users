using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases.Input;
using concord_users.Src.Infra.Persistence.Models;
using concord_users.Src.Infra.Http.Dtos;
using concord_users.Src.Domain.Enums;
using Microsoft.OpenApi.Extensions;

namespace concord_users.Src.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestDTO, CreateUserInput>();
            CreateMap<ListUsersRequestDTO, ListUsersInput>();
            CreateMap<CreateUserInput, User>();
                
            CreateMap<UserModel, User>()
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => Guid.Parse(src.Uuid)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatusConverter.ShortStringToEnum(src.Status)));
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => src.Uuid.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatusConverter.GetShortValue(src.Status)));
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => src.Uuid.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatusConverter.GetName(src.Status)));
        }
    }
}
