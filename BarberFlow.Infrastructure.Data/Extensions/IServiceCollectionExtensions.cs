using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarberFlow.Infrastructure.Data.Extensions;

public static class IServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDataLayer(string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString, sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
            });

            return services;
        }
    }
}
