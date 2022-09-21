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

namespace Application.Features.Reciepes.Commands.Create
{
    public class CreateReciepeCommand:IRequest<CreatedReciepeDto>
    {
        public string ReciepeName { get; set; }

        public class CreateReciepeCommandHandler:IRequestHandler<CreateReciepeCommand,CreatedReciepeDto>
        {
            private readonly IReciepeRepository _reciepeRepository;
            private readonly IMapper _mapper;

            public CreateReciepeCommandHandler(IReciepeRepository reciepeRepository, IMapper mapper)
            {
                _reciepeRepository = reciepeRepository;
                _mapper = mapper;
            }

            public async Task<CreatedReciepeDto> Handle(CreateReciepeCommand request, CancellationToken cancellationToken)
            {
                Reciepe? reciepe = _mapper.Map<Reciepe>(request);
                Reciepe mappedReciepe = _mapper.Map<Reciepe>(reciepe);
                Reciepe createdReciepe = await  _reciepeRepository.AddAsync(mappedReciepe);
                CreatedReciepeDto result = _mapper.Map<CreatedReciepeDto>(createdReciepe);
                return result;
            }
        }
    }
}
