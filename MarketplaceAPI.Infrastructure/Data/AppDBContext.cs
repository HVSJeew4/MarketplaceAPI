using MarketplaceAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Infrastructure.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
