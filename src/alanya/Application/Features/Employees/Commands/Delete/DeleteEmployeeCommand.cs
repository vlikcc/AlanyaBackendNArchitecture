using Application.Features.Employees.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
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
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler:IRequestHandler<DeleteEmployeeCommand,DeletedEmployeeDto>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }

            public async Task<DeletedEmployeeDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee? mappedEmployee = _mapper.Map<Employee>(request);
                Employee deletedEmployee = await _employeeRepository.DeleteAsync(mappedEmployee);  
                DeletedEmployeeDto result = _mapper.Map<DeletedEmployeeDto>(deletedEmployee);
                return result;  
            }
        }
    }
}
