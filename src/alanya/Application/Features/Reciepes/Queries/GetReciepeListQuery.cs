using Application.Features.Reciepes.Models;
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

namespace Application.Features.Reciepes.Queries
{
    public class GetReciepeListQuery:IRequest<ReciepeListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetRecipeListQueryHandler:IRequestHandler<GetReciepeListQuery,ReciepeListModel>
        {
            private readonly IReciepeRepository _reciepeRepository;
            private readonly IMapper _mapper;

            public GetRecipeListQueryHandler(IReciepeRepository reciepeRepository, IMapper mapper)
            {
                _reciepeRepository = reciepeRepository;
                _mapper = mapper;
            }

            public async Task<ReciepeListModel> Handle(GetReciepeListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Reciepe> reciepes = await _reciepeRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                 ReciepeListModel result = _mapper.Map<ReciepeListModel>(reciepes); 
                return result;
            }
        }
    }
}
