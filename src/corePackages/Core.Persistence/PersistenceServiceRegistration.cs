using Core.Helpers.Services.ConfigurationServices;
using Core.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IConfigurationService>(provider => new ConfigurationService(configuration));


            services.AddDbContextFactory<BaseDbContext>(options =>
              options.UseSqlServer(
                  GetDatabaseConnectionString(services),
                  sqlOptions => sqlOptions.MigrationsAssembly("Core.Persistence")
                      .EnableRetryOnFailure()
              )
              .LogTo(Console.WriteLine, LogLevel.Information)
          );


            return services;
        }

        private static string GetDatabaseConnectionString(IServiceCollection services)
        {
            // IConfigurationService oluşturma ya da erişim
            var serviceProvider = services.BuildServiceProvider();
            var configService = serviceProvider.GetRequiredService<IConfigurationService>();
            var configurationList = configService.GetConfigurationList();
            var secretConnectionString = configurationList.SecretClient.GetSecret("MyBlogDatabaseConnectionString");

            if (string.IsNullOrEmpty(secretConnectionString.Value.ToString()))
            {
                throw new ArgumentException("Database connection string is not properly formatted or is empty.");
            }

            return secretConnectionString.Value.Value;
        }
    }
}
