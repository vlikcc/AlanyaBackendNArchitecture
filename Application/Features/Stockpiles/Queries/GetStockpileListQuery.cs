using Application.Features.Stockpiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Stockpiles.Queries
{
    public class GetStockpileListQuery:IRequest<StockpileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetStockpileListQueryHandler:IRequestHandler<GetStockpileListQuery,StockpileListModel >
        {
            private readonly IStockpileRepository _stockpileRepository;
            private readonly IMapper _mapper;

            public GetStockpileListQueryHandler(IStockpileRepository stockpileRepository, IMapper mapper)
            {
                _stockpileRepository = stockpileRepository;
                _mapper = mapper;
            }

            public async Task<StockpileListModel> Handle(GetStockpileListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Stockpile> stocks = await _stockpileRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                StockpileListModel result = _mapper.Map<StockpileListModel>(stocks);
                return result;
            }
        }
    }
}
