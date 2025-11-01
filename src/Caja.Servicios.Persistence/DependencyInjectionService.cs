using Caja.Servicios.Application.DataBase;
using Caja.Servicios.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caja.Servicios.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration) {

            services.AddDbContext<DataBaseService>(opt => {
                opt.UseSqlServer(configuration["SQLConnectionString"]);
            });

            services.AddScoped<IDataBaseService, DataBaseService>();

            return services;
        }
    }
}
