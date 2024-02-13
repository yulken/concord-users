using concord_users.Infra.Mappers;

namespace concord_users.Infra.Config
{
    public class MappersConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
        }
    }
}
