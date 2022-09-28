using Application.Features.Reciepes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reciepes.Commands.Delete
{
    public class DeleteReciepeCommand:IRequest<DeletedReciepeDto>
    {
        public int Id { get; set; }
        public class DeleteReciepeCommandHandler:IRequestHandler<DeleteReciepeCommand,DeletedReciepeDto>
        {
            private readonly IReciepeRepository _recipeRepository;
            private readonly IMapper _mapper;

            public DeleteReciepeCommandHandler(IReciepeRepository recipeRepository, IMapper mapper)
            {
                _recipeRepository = recipeRepository;
                _mapper = mapper;
            }

            public async Task<DeletedReciepeDto> Handle(DeleteReciepeCommand request, CancellationToken cancellationToken)
            {
                Reciepe? reciepe = await _recipeRepository.GetAsync(r=>r.Id==request.Id);  
                Reciepe mappedReciepe = _mapper.Map<Reciepe>(reciepe);
                Reciepe deletedReciepe = await _recipeRepository.DeleteAsync(mappedReciepe);
                DeletedReciepeDto result = _mapper.Map<DeletedReciepeDto>(deletedReciepe);
                return result;
            }
        }
    }
}
