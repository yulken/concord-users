using concord_users.Domain.Ports;
using concord_users.Infra.Data.Repositories;

namespace concord_users.Infra.Config
{
    public class RepositoriesConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUserDataPort, UserRepository>();
        }
    }
}
