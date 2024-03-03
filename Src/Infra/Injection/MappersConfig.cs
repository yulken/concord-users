using concord_users.Src.Mappers;

namespace concord_users.Src.Infra.Config
{
    public class MappersConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
        }
    }
}
