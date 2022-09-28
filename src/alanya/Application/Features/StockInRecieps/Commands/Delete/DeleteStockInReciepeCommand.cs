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

namespace Application.Features.StockInRecieps.Commands.Delete
{
    public class DeleteStockInReciepeCommand:IRequest<DeletedStockInReciepeDto>
    {
        public int Id { get; set; }

        public class DeleteStockInReciepeCommandHandler:IRequestHandler<DeleteStockInReciepeCommand,DeletedStockInReciepeDto>
        {
            private readonly IStockInReciepeRepository _repository;
            private readonly IMapper _mapper;

            public DeleteStockInReciepeCommandHandler(IStockInReciepeRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DeletedStockInReciepeDto> Handle(DeleteStockInReciepeCommand request, CancellationToken cancellationToken)
            {
                StockInReciepe? stockInReciepe = await _repository.GetAsync(s => s.Id == request.Id);
                StockInReciepe mappedStockInReciepe = _mapper.Map<StockInReciepe>(stockInReciepe);
                StockInReciepe deletedStockInReciepe = await _repository.DeleteAsync(mappedStockInReciepe);
                DeletedStockInReciepeDto result = _mapper.Map<DeletedStockInReciepeDto>(deletedStockInReciepe);
                return result;
            }
        }
    }
}
