using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Infra.Persistence.Repositories;

namespace concord_users.Src.Infra.Injection
{
    public class AdaptersConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUserPersistencePort, UserRepository>();
        }
    }
}
