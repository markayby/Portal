using Portal.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Portal.AppConfig
{
    public static class DbConfiguration
    {
        public static readonly LoggerFactory DbLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Debug, true)
            });
        
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseLoggerFactory(DbLoggerFactory);
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), opt =>
                {
                    opt.CharSetBehavior(CharSetBehavior.AppendToAllUnicodeColumns);
                    opt.UnicodeCharSet(CharSet.Utf8mb4);
                });
            });            
        }

        public static void MigrateDb(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
        }
    }
}