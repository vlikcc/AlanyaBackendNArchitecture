using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StocksInReciepe:Entity
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ReciepeId { get; set; }
    }
}
