using ExemploHangfire.Worker.Services;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploHangfire.Worker.Config
{
    public static class HangfireConfig
    {
        public static IServiceCollection AddHangfireConfig(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddHangfire(config =>
            {
                if (isDevelopment)
                    config.UseStorage(new MemoryStorage());
                else
                    config.UseStorage(new MySqlStorage(configuration.GetConnectionString("Mysql_Hangfire"), new MySqlStorageOptions()));

            });
            return services;
        }

        public static IApplicationBuilder UseHangfireConfig(this IApplicationBuilder app, IRecurringJobManager backgroundJobs, IConfiguration configuration)
        {
            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.InitializeHangfireJobs(backgroundJobs, configuration);

            return app;
        }

        public static IApplicationBuilder InitializeHangfireJobs(this IApplicationBuilder app, IRecurringJobManager backgroundJobs, IConfiguration configuration)
        {
            backgroundJobs.AddOrUpdate<IExemploService>("Serviço de exemplo", service => service.Processar(), configuration.GetSection("Cron").Value, TimeZoneInfo.Local);
            return app;
        }
    }
}
