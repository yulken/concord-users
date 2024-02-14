using concord_users.Domain.Ports;
using concord_users.Infra.Data.Adapters;

namespace concord_users.Infra.Config
{
    public class AdaptersConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IListUserPort, ListUserAdapter>();
            services.AddScoped<ICreateUserPort, CreateUserAdapter>();
            services.AddScoped<IFindUserPort, FindUserAdapter>();
        }
    }
}
