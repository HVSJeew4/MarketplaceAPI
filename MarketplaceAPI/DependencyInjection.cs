using MarketplaceAPI.Application;
using MarketplaceAPI.Infrastructure;

namespace MarketplaceAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection service)
        {
            service.AddApplicationDI();
            service.AddInfrastructureDI();

            return service;
        }
    }
}
