using concord_users.Infra.Config;
using concord_users.Infra.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        string connectionString = BuildConnectionString();

        IServiceCollection services = builder.Services;
        services.AddDbContext<AppDbContext>(context => context.UseMySQL(connectionString));
        services.AddControllers();
        MappersConfig.Inject(services);
        RepositoriesConfig.Inject(services);
        UseCasesConfig.Inject(services);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

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
            Server = Environment.GetEnvironmentVariable("DB_HOST"),
            Database = Environment.GetEnvironmentVariable("DB_NAME"),
            UserID = Environment.GetEnvironmentVariable("DB_USER"),
            Password = Environment.GetEnvironmentVariable("DB_PASSWORD")
        };
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");

        logger.LogInformation(connString.ToString());
        return connString.ToString();
    }
}