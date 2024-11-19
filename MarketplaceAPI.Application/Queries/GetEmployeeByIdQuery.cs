using MarketplaceAPI.Core.Entities;
using MarketplaceAPI.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceAPI.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid employeeId):IRequest<EmployeeEntity>;
    
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        :IRequestHandler<GetEmployeeByIdQuery,EmployeeEntity>
    {
       public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request,CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeByIdAsync(request.employeeId);
        }
    }
}
