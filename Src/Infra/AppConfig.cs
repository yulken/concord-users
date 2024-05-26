namespace concord_users.Src.Infra
{
    public class AppConfig
    {
        public static string DbServer() 
        {
            return FetchEnvVariable("DB_HOST");
        }

        public static string DbDatabase()
        {
            return FetchEnvVariable("DB_NAME");
        }
        public static string DbUsername()
        {
            return FetchEnvVariable("DB_USER");
        }
        public static string DbPassword()
        {
            return FetchEnvVariable("DB_PASSWORD");
        }
        public static string AuthSecret()
        {
            return FetchEnvVariable("AUTH_SECRET");
        }
        public static string AuthApp()
        {
            return FetchEnvVariable("AUTH_APP");
        }
        private static string FetchEnvVariable(string variable)
        {
            string env = Environment.GetEnvironmentVariable(variable) 
                ?? throw new Exception("Variable " +  variable + " has not been set");
            return env;
        }
    }
}
