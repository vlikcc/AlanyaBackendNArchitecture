using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StockInRecieps.Dtos
{
    public class StockInReciepeListDto
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ReciepeId { get; set; }
        public decimal Price { get; set; }
    }
}
