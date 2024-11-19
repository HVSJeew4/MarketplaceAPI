using MarketplaceAPI.Core.Entities;
using MarketplaceAPI.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceAPI.Application.Commands
{
    public record UpdateEmployeeCommand(Guid EmployeeID,EmployeeEntity Employee)
        :IRequest<EmployeeEntity>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeeAsync(request.EmployeeID, request.Employee);        }
    }


}
