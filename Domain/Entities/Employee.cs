using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : Entity
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
    }
}
