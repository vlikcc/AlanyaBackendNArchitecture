using Application.Features.Stockpiles.Commands.Create;
using Application.Features.Stockpiles.Commands.Delete;
using Application.Features.Stockpiles.Commands.Update;
using Application.Features.Stockpiles.Dtos;
using Application.Features.Stockpiles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stockpiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Stockpile,CreatedStockpileDto>().ReverseMap();
            CreateMap<Stockpile,CreateStockpileCommand>().ReverseMap();

            CreateMap<Stockpile,DeletedStockpileDto>().ReverseMap();
            CreateMap<Stockpile,DeleteStockpileCommand>().ReverseMap();

            CreateMap<Stockpile, UpdatedStockpileDto>().ReverseMap();
            CreateMap<Stockpile, UpdateStockpileCommand>().ReverseMap();

            CreateMap<Stockpile, StockpileListDto>().ReverseMap();
            CreateMap<IPaginate<Stockpile>, StockpileListModel>().ReverseMap();
        }
    }
}
