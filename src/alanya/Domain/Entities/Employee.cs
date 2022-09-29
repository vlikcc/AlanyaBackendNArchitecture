using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : Entity
    {
       
        public int UserId { get; set; }

        public string? NationalId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? EmailAdress { get; set; }
        public decimal? Salary { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Department { get; set; }
        public virtual User? User { get; set; }

        public Employee(int id,  int userId,string nationalId, string firstName, string lastName, string phoneNumber, string address, string emailAdress, decimal salary, string maritalStatus, string department)
        {
            Id = id;
            UserId = userId;           
            NationalId = nationalId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            EmailAdress = emailAdress;
            Salary = salary;
            MaritalStatus = maritalStatus;
            Department = department;
        }

        public Employee()
        {
        }

       

    }
}
