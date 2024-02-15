using AutoMapper;
using concord_users.Src.Mappers;
using concord_users.Test.UseCases;

namespace concord_users.Test
{
    public class TestDependencies
    {
        public static ILogger<T> GetLogger<T>()
        {
            ILogger<T> logger = new LoggerFactory().CreateLogger<T>();
            return logger;
        }

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
