using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRecpository;

        public CustomerBusinessRules(ICustomerRepository customerRecpository)
        {
            _customerRecpository = customerRecpository;
        }

        public async Task EmailCannotBeDublicated(string eMail)
        {
            IPaginate<Customer> result = await _customerRecpository.GetListAsync(c => c.Email == eMail);
            if (result.Items.Any()) throw new BusinessException("Email Can Not Be Dublicated");

        }

        public async Task CustomerShouldExistWhenRequested(Customer request)
        {
            if (request == null) throw new BusinessException("Customer does not excist.");
        }
    }
}
