using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand:IRequest<DeletedCustomerDto>
    {
        public int Id { get; set; }

        public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommand,DeletedCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _businessRules;

            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules businessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletedCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(c => c.Id == request.Id);
                await _businessRules.CustomerShouldExistWhenRequested(customer);
                Customer deletedCustomer = _mapper.Map<Customer>(customer);
                await _customerRepository.DeleteAsync(deletedCustomer);
                DeletedCustomerDto result = _mapper.Map<DeletedCustomerDto>(deletedCustomer);
                return result;
            }
        }
    }
}
