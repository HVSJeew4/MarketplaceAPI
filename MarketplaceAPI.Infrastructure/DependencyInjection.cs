using MarketplaceAPI.Core.Interfaces;
using MarketplaceAPI.Infrastructure.Data;
using MarketplaceAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketplaceAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection service)
        {
            
            service.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-UV92TIS;Database=TestAPIDB;Trusted_Connection=True;TrustServerCertificate=True;User Id=machcha;Password=machcha12345;Trusted_Connection=True;TrustServerCertificate=True;User Id=machcha;Password=machcha12345;");

            });
            
            service.AddScoped<IEmployeeRepository,EmployeeRepository>();

            return service;
        }
    }
}
