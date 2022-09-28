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

namespace Application.Features.Employees.Commands.Update
{
    public class UpdateEmployeeCommand:IRequest<UpdatedEmployeeDto>
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAdress { get; set; }
        public decimal Salary { get; set; }
        public string MaritalStatus { get; set; }
        public string Department { get; set; }

        public class UpdateEmployeeCommandHandler:IRequestHandler<UpdateEmployeeCommand,UpdatedEmployeeDto>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedEmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee? employee = await _employeeRepository.GetAsync(e => e.Id == request.Id);
                Employee updatedEmployee = _mapper.Map<Employee>(employee);
                updatedEmployee.FirstName = request.FirstName;
                updatedEmployee.LastName = request.LastName;
                updatedEmployee.PhoneNumber = request.PhoneNumber;
                updatedEmployee.Address = request.Address;
                updatedEmployee.EmailAdress = request.EmailAdress;
                updatedEmployee.Salary = request.Salary;
                updatedEmployee.MaritalStatus = request.MaritalStatus;
                updatedEmployee.Department = request.Department;
                await _employeeRepository.UpdateAsync(updatedEmployee);
                UpdatedEmployeeDto result = _mapper.Map<UpdatedEmployeeDto>(updatedEmployee);
                return result;

            }
        }
    }
}
