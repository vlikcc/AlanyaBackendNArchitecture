using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reciepes.Dtos
{
    public class ReciepeListDto
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public decimal RecipeCost { get; set; }
    }
}
