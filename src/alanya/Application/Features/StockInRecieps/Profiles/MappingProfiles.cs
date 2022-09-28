using Application.Features.StockInRecieps.Commands.Create;
using Application.Features.StockInRecieps.Commands.Delete;
using Application.Features.StockInRecieps.Commands.Update;
using Application.Features.StockInRecieps.Dtos;
using Application.Features.StockInRecieps.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StockInRecieps.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<StockInReciepe, CreatedStockInReciepeDto>().ReverseMap();
            CreateMap<StockInReciepe,CreateStockInReciepeCommand>().ReverseMap();

            CreateMap<StockInReciepe, DeletedStockInReciepeDto>().ReverseMap();
            CreateMap<StockInReciepe, DeleteStockInReciepeCommand>().ReverseMap();

            CreateMap<StockInReciepe, UpdatedStockInReciepeDto>().ReverseMap();
            CreateMap<StockInReciepe, UpdateStockInReciepeCommand>().ReverseMap();

            CreateMap<StockInReciepe, StockInReciepeListDto>().ReverseMap();
            CreateMap<IPaginate<StockInReciepe>, StockInReciepeListModel>().ReverseMap();
        }
    }
}
