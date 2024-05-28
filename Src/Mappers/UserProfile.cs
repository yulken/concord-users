using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.UseCases.Users.Input;
using concord_users.Src.Infra.Http.Dtos.Users;
using concord_users.Src.Infra.Persistence.Models;

namespace concord_users.Src.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestDTO, CreateUserInput>();
            CreateMap<ListUsersRequestDTO, FindUsersInput>();

            CreateMap<ListUsersRequestDTO, Pagination>()
                .ForMember(dest => dest.OrderBy, opt => opt.MapFrom(src => OrderByEnumUtil.Get(src.OrderBy)));
                
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => src.Uuid.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatusUtil.GetShortValue(src.Status)));
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => src.Uuid.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatusUtil.GetName(src.Status)));
        }
    }
}
