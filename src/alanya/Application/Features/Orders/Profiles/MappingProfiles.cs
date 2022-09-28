using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Commands.Delete;
using Application.Features.Orders.Commands.Update;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreatedOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();

            CreateMap<Order,UpdatedOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();

            CreateMap<Order, DeletedOrderDto>().ReverseMap();
            CreateMap<Order, DeleteOrderCommand>().ReverseMap();

            CreateMap<Order,OrderListDto>().ReverseMap();
            CreateMap<IPaginate<Order>, OrderListModel>().ReverseMap();
        }
    }
}
