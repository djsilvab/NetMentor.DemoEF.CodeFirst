using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Interceptors;
using NetMentor.DemoEF.CodeFirst.Entities.Settings;

namespace NetMentor.DemoEF.CodeFirst.Data.Connections
{
    public static class DataBaseDiExtensions
    {
        public static void AddMySql(this IServiceCollection services, IConfiguration configuration)
        {
            //var ipServer = configuration["DataBase:Server"];
            //var AllowUserVariables = configuration.GetValue<bool>("DataBase:AllowUserVariables");

            //IConfigurationSection section = configuration.GetSection("DataBase");
            //var dbSettings = section.Get<DataBaseSettings>();
            //var portServerX = dbSettings.Port;

            //var portServer = section.GetValue<int>("Port");
            //var dataBaseName = section.GetValue<string>("Name");

            //DataBaseSettings dataBaseSettings = new();
            //configuration.Bind("DataBase", dataBaseSettings);

            services.AddDbContext<NorthwindContext>(options => {
                    options
                    .UseLazyLoadingProxies()
                    .AddInterceptors(new ReadExampleInterceptor())
                    .UseMySQL(configuration.GetConnectionString("MySqlConnection"));
            });
        }

        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));
            });
        }

        public static void AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
            });
        }

        public static void AddSqlLite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("SqlLiteConnection"));
            });
        }

        public static void AddOracle(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options =>
                options.UseOracle(configuration.GetConnectionString("OracleConnection")));
        }
    }
}
