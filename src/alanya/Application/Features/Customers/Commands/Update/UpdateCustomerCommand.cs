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

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand:IRequest<UpdatedCustomerDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand,UpdatedCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _businessRules;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules businessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(c=>c.Id == request.Id);
                Customer updatedCustomer = _mapper.Map<Customer>(customer);
                updatedCustomer.FirstName = request.FirstName;
                updatedCustomer.LastName = request.LastName;
                updatedCustomer.Adress = request.Adress;
                updatedCustomer.TelephoneNumber = request.TelephoneNumber;
                updatedCustomer.Email = request.Email;
                await _businessRules.EmailCannotBeDublicated(updatedCustomer.Email);
                await _customerRepository.UpdateAsync(updatedCustomer); 
                UpdatedCustomerDto result = _mapper.Map<UpdatedCustomerDto>(updatedCustomer);
                return result;
                
            }
        }
    }
}
