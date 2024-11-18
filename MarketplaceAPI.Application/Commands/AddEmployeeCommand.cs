﻿using MarketplaceAPI.Core.Entities;
using MarketplaceAPI.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceAPI.Application.Commands
{
    public record AddEmployeeCommand(EmployeeEntity Employee) :IRequest<EmployeeEntity>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
           return await employeeRepository.AddEmployeeAsync(request.Employee);
        }
    }

}
