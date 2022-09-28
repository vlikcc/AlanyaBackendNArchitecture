using Application.Features.StockInRecieps.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StockInRecieps.Commands.Create
{
    public class CreateStockInReciepeCommand:IRequest<CreatedStockInReciepeDto>
    {
        public int StockId { get; set; }
        public int ReciepeId { get; set; }
        public decimal Price { get; set; }

        public class CreateStockInReciepeCommandRequest:IRequestHandler<CreateStockInReciepeCommand,CreatedStockInReciepeDto>
        {
            private readonly IStockInReciepeRepository _repository;
            private readonly IMapper _mapper;

            public CreateStockInReciepeCommandRequest(IStockInReciepeRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreatedStockInReciepeDto> Handle(CreateStockInReciepeCommand request, CancellationToken cancellationToken)
            {
                StockInReciepe stockInReciepe = _mapper.Map<StockInReciepe>(request);
                StockInReciepe createdStockInReciepe = await _repository.AddAsync(stockInReciepe);
                CreatedStockInReciepeDto result = _mapper.Map<CreatedStockInReciepeDto>(createdStockInReciepe);
                return result;
                
            }
        }
    }
}
