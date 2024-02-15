using concord_users.Src.Domain.UseCases;
using concord_users.Src.Domain.UseCases.Impl;

namespace concord_users.Src.Infra.Config
{
    public class UseCasesConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IListUsersUseCase, ListUsersUseCase>();
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<IFindUserUseCase, FindUserUseCase>();
        }
    }
}
