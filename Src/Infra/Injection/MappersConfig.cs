using concord_users.Src.Mappers;

namespace concord_users.Src.Infra.Injection
{
    public class MappersConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
        }
    }
}
