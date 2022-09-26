using Application.Features.Reciepes.Commands.Create;
using Application.Features.Reciepes.Commands.Delete;
using Application.Features.Reciepes.Commands.Update;
using Application.Features.Reciepes.Dtos;
using Application.Features.Reciepes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reciepes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Reciepe,CreateReciepeCommand>().ReverseMap();
            CreateMap<Reciepe, CreatedReciepeDto>().ReverseMap();

            CreateMap<Reciepe, UpdatedReciepeDto>().ReverseMap();
            CreateMap<Reciepe, UpdateReciepeCommand>().ReverseMap();

            CreateMap<Reciepe, DeleteReciepeCommand>().ReverseMap();
            CreateMap<Reciepe, DeletedReciepeDto>().ReverseMap();

            CreateMap<Reciepe,ReciepeListDto>().ReverseMap();
            CreateMap<IPaginate<Reciepe>, ReciepeListModel>().ReverseMap();

            
        }
    }
}
