using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Stockpile : Entity
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public string Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpirationDate { get; set; }   

        public Stockpile(int id, string stockName, string unit, decimal amount, decimal cost, DateTime expirationDate)
        {
            Id = id;
            StockName = stockName;
            Unit = unit;
            Amount = amount;
            Cost = cost;
            ExpirationDate = expirationDate;
        }

        public Stockpile()
        {
        }
    }
}
