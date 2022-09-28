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

namespace Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand:IRequest<CreatedCustomerDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommand,CreatedCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _businessRules;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules businessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer mappedCustomer = _mapper.Map<Customer>(request);
                await _businessRules.EmailCannotBeDublicated(mappedCustomer.Email);
                Customer createdCustomer = await _customerRepository.AddAsync(mappedCustomer);
                CreatedCustomerDto result = _mapper.Map<CreatedCustomerDto>(createdCustomer);   
                return result;

            }
        }
    }
}
