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

namespace Application.Features.Employees.Commands.Create
{
    public class CreateEmployeeCommand:IRequest<CreatedEmployeeDto>
    {
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAdress { get; set; }
        public decimal Salary { get; set; }
        public string MaritalStatus { get; set; }
        public string Department { get; set; }

        public class CreateEmployeeCommandHandler:IRequestHandler<CreateEmployeeCommand,CreatedEmployeeDto>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }

            public async Task<CreatedEmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee? mappedEmployee = _mapper.Map<Employee>(request);
                Employee createdEmployee = await _employeeRepository.AddAsync(mappedEmployee);
               CreatedEmployeeDto result = _mapper.Map<CreatedEmployeeDto>(createdEmployee);
                return result;
            }
        }
    }
}
