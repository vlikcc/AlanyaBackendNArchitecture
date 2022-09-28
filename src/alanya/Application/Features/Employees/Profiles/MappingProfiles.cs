using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Commands.Delete;
using Application.Features.Employees.Commands.Update;
using Application.Features.Employees.Dtos;
using Application.Features.Employees.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee,CreatedEmployeeDto>().ReverseMap();
            CreateMap<Employee,CreateEmployeeCommand>().ReverseMap();

            CreateMap<Employee,UpdatedEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();

            CreateMap<Employee,DeletedEmployeeDto>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();

            CreateMap<Employee,EmployeeListDto>().ReverseMap();
            CreateMap<IPaginate<Employee>,EmployeeListModel>().ReverseMap();


        }
    }
}
