using MarketplaceAPI.Core.Entities;
using MarketplaceAPI.Core.Interfaces;
using MarketplaceAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDBContext dBContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await dBContext.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id)
        {
            return await dBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dBContext.Employees.Add(entity);
            await dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity entity)
        {
            var employee = await dBContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee is not null)
            {
                employee.Name = entity.Name;
                employee.Email = entity.Email;
                employee.Phone = entity.Phone;

                await dBContext.SaveChangesAsync();
                return employee;
            }
            return entity;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await dBContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee is not null)
            {
                dBContext.Employees.Remove(employee);
                return await dBContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
