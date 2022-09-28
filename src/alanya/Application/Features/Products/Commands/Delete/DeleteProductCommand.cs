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

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand:IRequest<DeletedProductDto>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand,DeletedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(p=>p.Id==request.Id);
                Product mappedProduct = _mapper.Map<Product>(product);
                Product deletedProduct = await _productRepository.DeleteAsync(mappedProduct);
                DeletedProductDto result = _mapper.Map<DeletedProductDto>(deletedProduct);  
                return result;               
                
            }
        }
    }
}
