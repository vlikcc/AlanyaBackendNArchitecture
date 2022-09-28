using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StockInRecieps.Dtos
{
    public class UpdatedStockInReciepeDto
    {
        public int StockId { get; set; }
        public int ReciepeId { get; set; }
        public decimal Price { get; set; }
    }
}
