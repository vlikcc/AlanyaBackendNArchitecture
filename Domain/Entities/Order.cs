using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : Entity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual List<Product> Products { get; set; }

        public Order(int id, int customerId, int employeeId, DateTime orderDate, bool orderStatus)
        {
            Id = id;
            CustomerId = customerId;
            EmployeeId = employeeId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }

        public Order()
        {
        }
    }
}
