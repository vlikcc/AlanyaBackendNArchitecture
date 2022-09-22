using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockInReciepe:Entity
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ReciepeId { get; set; }
        public decimal Amount { get; set; } 
        public decimal Price { get; set; }  
        public virtual Stockpile Stockpile { get; set; }
        public virtual Reciepe Reciepe { get; set; }

        public StockInReciepe(int id, int stockId, int reciepeId)
        {
            Id = id;
            StockId = stockId;
            ReciepeId = reciepeId;
        }

        public StockInReciepe()
        {
        }
    }
}
