using Application.Features.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Models
{
    public class ProductListModel
    {
        public List<ProductListDto> Items { get; set; }
    }
}
