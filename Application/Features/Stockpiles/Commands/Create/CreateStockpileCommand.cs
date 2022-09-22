using Application.Features.Stockpiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stockpiles.Commands.Create
{
    public class CreateStockpileCommand:IRequest<CreatedStockpileDto>
    {
        public string StockName { get; set; }
        public string Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpirationDate { get; set; }

        public class CreateStockpileCommandHandler:IRequestHandler<CreateStockpileCommand,CreatedStockpileDto>
        {
            private readonly IStockpileRepository _stockpileRepository;
            private readonly IMapper _mapper;

            public CreateStockpileCommandHandler(IStockpileRepository stockpileRepository, IMapper mapper)
            {
                _stockpileRepository = stockpileRepository;
                _mapper = mapper;
            }

            public async Task<CreatedStockpileDto> Handle(CreateStockpileCommand request, CancellationToken cancellationToken)
            {
                Stockpile stockpile = _mapper.Map<Stockpile>(request);
                Stockpile createdStockpile = await _stockpileRepository.AddAsync(stockpile);
                CreatedStockpileDto result = _mapper.Map<CreatedStockpileDto>(createdStockpile);
                return result;  

            }
        }
    }
}
