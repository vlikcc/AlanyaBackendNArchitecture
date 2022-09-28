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

namespace Application.Features.Stockpiles.Commands.Update
{
    public class UpdateStockpileCommand:IRequest<UpdatedStockpileDto>
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public string Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpirationDate { get; set; }
        public class UpdateStockpileCommandHandler:IRequestHandler<UpdateStockpileCommand,UpdatedStockpileDto>
        {
            private readonly IStockpileRepository _stockpileRepository;
            private readonly IMapper _mapper;

            public UpdateStockpileCommandHandler(IStockpileRepository stockpileRepository, IMapper mapper)
            {
                _stockpileRepository = stockpileRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedStockpileDto> Handle(UpdateStockpileCommand request, CancellationToken cancellationToken)
            {
                Stockpile? stockpile = await _stockpileRepository.GetAsync(s => s.Id == request.Id);
                stockpile.StockName = request.StockName;
                stockpile.Unit = request.Unit;
                stockpile.Amount = request.Amount;
                stockpile.Cost = request.Cost;  
                stockpile.ExpirationDate = request.ExpirationDate;
                Stockpile mappedStockpile = _mapper.Map<Stockpile>(stockpile);
                Stockpile updatedStockpile = await _stockpileRepository.UpdateAsync(mappedStockpile);
                UpdatedStockpileDto result = _mapper.Map<UpdatedStockpileDto>(updatedStockpile);
                return result;

            }
        }
    }
}
