using Application.Features.Reciepes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reciepes.Models
{
    public class ReciepeListModel
    {
        public List<ReciepeListDto> Items { get; set; }
    }
}
