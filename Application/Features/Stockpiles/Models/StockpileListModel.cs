using Application.Features.Stockpiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stockpiles.Models
{
    public class StockpileListModel
    {
        public List<StockpileListDto> Items { get; set; }   
    }
}
