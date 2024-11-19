using MarketplaceAPI.Application.Commands;
using MarketplaceAPI.Application.Queries;
using MarketplaceAPI.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeEntity employee)
        {
            var result = await _sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await _sender.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await _sender.Send(new GetEmployeeByIdQuery(employeeId));
            return Ok(result);
        }

        [HttpPut("UpdateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] EmployeeEntity employee)
        {
            {
                var result = await _sender.Send(new UpdateEmployeeCommand(employeeId, employee));
                return Ok(result);
            }


        }

        [HttpDelete("DeleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            {
                var result = await _sender.Send(new DeleteEmployeeCommand(employeeId));
                return Ok(result);
            }


        }
    }
}
