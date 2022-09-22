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

namespace Application.Features.Stockpiles.Commands.Delete
{
    public class DeleteStockpileCommand:IRequest<DeletedStockpileDto>
    {
        public int Id { get; set; }

        public class DeleteStockpileCommandHandler:IRequestHandler<DeleteStockpileCommand,DeletedStockpileDto>
        {
            private readonly IStockpileRepository _stockpileRepository;
            private readonly IMapper _mapper;

            public DeleteStockpileCommandHandler(IStockpileRepository stockpileRepository, IMapper mapper)
            {
                _stockpileRepository = stockpileRepository;
                _mapper = mapper;
            }

            public async Task<DeletedStockpileDto> Handle(DeleteStockpileCommand request, CancellationToken cancellationToken)
            {
                Stockpile? stockpile = await _stockpileRepository.GetAsync(s => s.Id == request.Id);
                Stockpile mappedStockpile = _mapper.Map<Stockpile>(stockpile);
                Stockpile  deletedStockpile = await _stockpileRepository.DeleteAsync(mappedStockpile);
                DeletedStockpileDto result = _mapper.Map<DeletedStockpileDto>(deletedStockpile);
                return result;
            }
        }
    }
}
