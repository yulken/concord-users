using concord_users.Src.Infra;
using concord_users.Src.Infra.Http.Filters;
using concord_users.Src.Infra.Injection;
using concord_users.Src.Infra.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        string connectionString = BuildConnectionString();

        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger(AppConfig.AuthApp());

        IServiceCollection services = builder.Services;
        services.AddDbContext<AppDbContext>(context => context.UseMySQL(connectionString));
        services.AddControllers(options => options.Filters.Add<HttpResponseExceptionFilter>());

        MappersConfig.Inject(services);
        AdaptersConfig.Inject(services);
        UseCasesConfig.Inject(services);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        byte[] key = Encoding.ASCII.GetBytes(AppConfig.AuthSecret());
        services
            .AddAuthentication(ConfigureAuthentication)
            .AddJwtBearer(jwtBearerOptions => ConfigureJwtBearer(jwtBearerOptions, key));

        WebApplication app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static string BuildConnectionString()
    {
        MySqlConnectionStringBuilder connString = new()
        {
            Server = AppConfig.DbServer(),
            Database = AppConfig.DbDatabase(),
            UserID = AppConfig.DbUsername(),
            Password = AppConfig.DbPassword()
        };

        return connString.ToString();
    }

    private static void ConfigureAuthentication(AuthenticationOptions authOptions)
    {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }

    private static void ConfigureJwtBearer(JwtBearerOptions jwtBearerOptions, byte[] key)
    {
        jwtBearerOptions.SaveToken = true;
        jwtBearerOptions.ClaimsIssuer = AppConfig.AuthApp();
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    }
}