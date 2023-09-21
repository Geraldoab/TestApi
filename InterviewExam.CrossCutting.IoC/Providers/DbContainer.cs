using InterviewExam.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewExam.CrossCutting.IoC.Providers
{
    internal static class DbContainer
    {
        internal static void Register(IServiceCollection services, IConfiguration configuration, bool isTest = false)
        {
            if (isTest)
                UserInMemoryDatabase(services);

            UseSqliteDatabase(services, configuration);
        }

        private static void UseSqliteDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqLiteConnection");

            services.AddDbContext<InterviewExamContext>(dbOptions => 
            { 
                dbOptions.UseSqlite(connectionString, db => 
                {
                    db.MigrationsAssembly("InterviewExam.Infrastructure.Data.Context");
                });
            });
        }

        private static void UserInMemoryDatabase(IServiceCollection services)
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            services.AddDbContext<InterviewExamContext>(o => o
                .UseInternalServiceProvider(serviceProvider)
                .UseInMemoryDatabase(Guid.NewGuid().ToString()),
                contextLifetime: ServiceLifetime.Scoped);
        }
    }
}
