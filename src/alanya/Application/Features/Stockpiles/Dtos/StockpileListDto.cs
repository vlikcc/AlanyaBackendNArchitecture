using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stockpiles.Dtos
{
    public  class StockpileListDto
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public string Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
