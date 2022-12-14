using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand:IRequest<CreatedProductDto>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public DateTime ExpirationDate { get; set; }

        public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand,CreatedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = _mapper.Map<Product>(request);
                Product createdProduct = await _productRepository.AddAsync(product);
                CreatedProductDto result = _mapper.Map<CreatedProductDto>(createdProduct);
                return result;

            }
        }
    }
}
