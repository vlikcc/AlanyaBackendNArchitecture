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

namespace Application.Features.StockInRecieps.Commands.Update
{
    public class UpdateStockInReciepeCommand : IRequest<UpdatedStockInReciepeDto>
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ReciepeId { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public class UpdateStockInRecipeCommandHandler : IRequestHandler<UpdateStockInReciepeCommand, UpdatedStockInReciepeDto>
        {
            private readonly IStockInReciepeRepository _repository;
            private readonly IMapper _mapper;

            public UpdateStockInRecipeCommandHandler(IStockInReciepeRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<UpdatedStockInReciepeDto> Handle(UpdateStockInReciepeCommand request, CancellationToken cancellationToken)
            {
                StockInReciepe? stockInReciepe = await _repository.GetAsync(s => s.Id == request.Id);
                stockInReciepe.StockId = request.StockId;
                stockInReciepe.ReciepeId = request.ReciepeId;
                stockInReciepe.Price = request.Price;
                stockInReciepe.Amount = request.Amount;
                StockInReciepe mappedStockInReciepe = _mapper.Map<StockInReciepe>(stockInReciepe);  
                StockInReciepe updatedStockInReciepe = await _repository.UpdateAsync(mappedStockInReciepe);
                UpdatedStockInReciepeDto result = _mapper.Map<UpdatedStockInReciepeDto>(updatedStockInReciepe);
                return result;

                
            }
        }
    }
}
