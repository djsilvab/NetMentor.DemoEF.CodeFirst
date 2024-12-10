using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Connections
{
    public static class DataBaseDiExtensions
    {
        public static void AddMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options => {
                options.UseMySQL(configuration.GetConnectionString("MySqlConnection"));
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
