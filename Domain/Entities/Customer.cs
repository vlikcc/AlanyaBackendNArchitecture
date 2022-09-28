using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{
    public class Customer :Entity
    {
        
        
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public virtual User User { get; set; }

        public Customer(int id, int userId, string firstName, string lastName, string adress, string telephoneNumber, string email)
        {
            Id = id;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            TelephoneNumber = telephoneNumber;
            Email = email;
        }

        public Customer()
        {
        }
    }
}
