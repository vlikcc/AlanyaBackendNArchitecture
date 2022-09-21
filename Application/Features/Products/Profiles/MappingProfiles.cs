using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,CreateProductCommand>().ReverseMap();
            CreateMap<Product,CreatedProductDto>().ReverseMap();

            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product,DeletedProductDto>().ReverseMap();

            CreateMap<Product,UpdatedProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            CreateMap<Product,ProductListDto>().ReverseMap();
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();

        }
    }
}
