using Application.Features.Customers.Models;
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

namespace Application.Features.Customers.Queries
{
    public class GetListCustomerQuery:IRequest<CustomerListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCustomerQueryHandler:IRequestHandler<GetListCustomerQuery,CustomerListModel>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CustomerListModel> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Customer> customers = await _customerRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                CustomerListModel result = _mapper.Map<CustomerListModel>(customers);
                return result;
            }
        }
    }
}
