using concord_users.Src.Domain.UseCases.Auth;
using concord_users.Src.Domain.UseCases.Auth.Impl;
using concord_users.Src.Domain.UseCases.Users;
using concord_users.Src.Domain.UseCases.Users.Impl;

namespace concord_users.Src.Infra.Injection
{
    public class UseCasesConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IListUsersUseCase, ListUsersUseCase>();
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<IFindUserUseCase, FindUserUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            AddEnvSpecificServices(services);

        }

        private static void AddEnvSpecificServices(IServiceCollection services)
        {
            if (AppConfig.Env() == "Development")
            {
                services.AddScoped<IAuthenticateUseCase, AuthenticateTestEnvUseCase>();
                return;
            }

            services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();
        }
    }
}
