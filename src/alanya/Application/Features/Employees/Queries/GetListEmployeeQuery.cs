using Application.Features.Employees.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public class GetListEmployeeQuery:IRequest<EmployeeListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListEmployeeQueryHandler:IRequestHandler<GetListEmployeeQuery,EmployeeListModel>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public GetListEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }

            public async Task<EmployeeListModel> Handle(GetListEmployeeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Employee> employees = await _employeeRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                EmployeeListModel result = _mapper.Map<EmployeeListModel>(employees);
                return result;

            }
        }
    }
}
