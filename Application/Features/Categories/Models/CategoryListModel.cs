using Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Models
{
    public class CategoryListModel
    {
        public List<CategoryListDto> Items { get; set; }
    }
}
