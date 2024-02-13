using concord_users.Domain.UseCases.Impl;
using concord_users.Domain.UseCases;

namespace concord_users.Infra.Config
{
    public class UseCasesConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IListUsers, ListUsers>();
        }
    }
}
