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
        
        public int? CategoryId { get; set; }
        public int? ProductImageId { get; set; }
        public int? RecipeId { get; set; }
        public int? DiscountId { get; set; }
        public int? UnitId { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public virtual Category? Category { get; set; }

        public Product(int id, int categoryId, int productImageId, int recipeId, int discountId, int unitId, string productName, decimal unitPrice, int unitsInStock, DateTime expirationDate)
        {
            Id = id;
            CategoryId = categoryId;
            ProductImageId = productImageId;
            RecipeId = recipeId;
            DiscountId = discountId;
            UnitId = unitId;
            ProductName = productName;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            ExpirationDate = expirationDate;
        }

        public Product()
        {
        }
    }
}
