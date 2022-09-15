using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductImageId { get; set; }
        public int RecipeId { get; set; }
        public int DiscountId { get; set; }
        public int UnitId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
