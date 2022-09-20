using Application.Features.Employees.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Models
{
    public class EmployeeListModel
    {
        List<EmployeeListDto> Items { get; set; }   
    }
}
