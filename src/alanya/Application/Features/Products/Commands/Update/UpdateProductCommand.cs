using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand:IRequest<UpdatedProductDto>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public DateTime ExpirationDate { get; set; }

        public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand,UpdatedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);
                product.ProductName = request.ProductName;
                product.UnitPrice = request.UnitPrice;
                product.UnitsInStock = request.UnitsInStock;
                product.ExpirationDate = request.ExpirationDate;
                Product mappedProduct = _mapper.Map<Product>(product);  
                Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
                UpdatedProductDto result = _mapper.Map<UpdatedProductDto>(updatedProduct);
                return result;

            }
        }
    }
}
