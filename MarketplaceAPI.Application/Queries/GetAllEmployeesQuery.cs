using MarketplaceAPI.Core.Entities;
using MarketplaceAPI.Core.Interfaces;
using MediatR;

namespace MarketplaceAPI.Application.Queries
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeEntity>>;

    public class GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>
    {
        public async Task<IEnumerable<EmployeeEntity>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployees();
        }
    }

}
