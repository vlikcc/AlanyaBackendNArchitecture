using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Models;
using Application.Features.Customers.Queries;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer,CreatedCustomerDto>().ReverseMap();

            CreateMap<Customer,UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer,UpdatedCustomerDto>().ReverseMap();

            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer,DeletedCustomerDto>().ReverseMap();

            CreateMap<Customer,CustomerListDto>().ReverseMap();
            CreateMap<IPaginate<Customer>,CustomerListModel>().ReverseMap();  
        }
    }
}
