using Application.Features.Employees.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<DeletedEmployeeDto>
    {

    }
}
