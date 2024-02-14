using concord_users.Mappers;

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
