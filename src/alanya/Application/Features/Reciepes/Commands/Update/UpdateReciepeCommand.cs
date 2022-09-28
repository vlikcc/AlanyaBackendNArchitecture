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

namespace Application.Features.Reciepes.Commands.Update
{
    public class UpdateReciepeCommand:IRequest<UpdatedReciepeDto>
    {
        public int Id { get; set; }
        public string ReciepeName { get; set; }

        public class UpdateReciepeCommandHandler:IRequestHandler<UpdateReciepeCommand,UpdatedReciepeDto>
        {
            private readonly IReciepeRepository _reciepeRepository;
            private readonly IMapper _mapper;

            public async Task<UpdatedReciepeDto> Handle(UpdateReciepeCommand request, CancellationToken cancellationToken)
            {
                Reciepe? reciepe = await _reciepeRepository.GetAsync(r => r.Id == request.Id);
                reciepe.RecipeName = request.ReciepeName;
                Reciepe mappedReciepe = _mapper.Map<Reciepe>(reciepe); 
                Reciepe updatedReciepe = await _reciepeRepository.UpdateAsync(mappedReciepe);
                UpdatedReciepeDto result = _mapper.Map<UpdatedReciepeDto>(updatedReciepe);
                return result;

            }
        }
    }
}
