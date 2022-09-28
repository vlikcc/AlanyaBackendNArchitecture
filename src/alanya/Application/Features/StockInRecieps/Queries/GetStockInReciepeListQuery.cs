using Application.Features.StockInRecieps.Models;
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

namespace Application.Features.StockInRecieps.Queries
{
    public class GetStockInReciepeListQuery:IRequest<StockInReciepeListModel>
    {
        public PageRequest PageRequest { get; set; }    

        public class GetStockInReciepeListQueryHandler:IRequestHandler<GetStockInReciepeListQuery,StockInReciepeListModel>
        {
            private readonly IStockInReciepeRepository _repository;
            private readonly IMapper _mapper;

            public async Task<StockInReciepeListModel> Handle(GetStockInReciepeListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<StockInReciepe > stockInReciepes = await _repository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                StockInReciepeListModel result = _mapper.Map<StockInReciepeListModel>(stockInReciepes);
                return result;
            }
        }
    }
}
