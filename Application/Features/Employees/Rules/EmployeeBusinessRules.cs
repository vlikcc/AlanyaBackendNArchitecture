using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Rules
{
    public class EmployeeBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task NationalIdentityCannotBeDublicated(string nationalIdentity)
        {
           IPaginate<Employee> result = await _employeeRepository.GetListAsync(e=>e.NationalId == nationalIdentity);
            if (result.Items.Any()) throw new BusinessException("National Identitiy Cannot Be Dublicated.");
        }
    }
}
