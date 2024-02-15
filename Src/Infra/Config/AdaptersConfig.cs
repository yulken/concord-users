﻿using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Infra.Data.Repositories;

namespace concord_users.Src.Infra.Config
{
    public class AdaptersConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUserPersistencePort, UserRepository>();
        }
    }
}
