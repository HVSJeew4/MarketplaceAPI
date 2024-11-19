using MarketplaceAPI.Core.Interfaces;
using MediatR;

namespace MarketplaceAPI.Application.Commands
{
    public record DeleteEmployeeCommand(Guid employeeId) : IRequest<bool>;

    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeeAsync(request.employeeId);
        }
    }
}
