using Application.Features.StockInRecieps.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StockInRecieps.Models
{
    public class StockInReciepeListModel
    {
        public List<StockInReciepeListDto> Items { get; set; }  
    }
}
