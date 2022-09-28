using Application.Features.Orders.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.Delete
{
    public class DeleteOrderCommand:IRequest<DeletedOrderDto>
    {
        public int Id { get; set; }

        public class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommand,DeletedOrderDto>
        {
            private readonly IOrderRepository _orderRepoitory;
            private readonly IMapper _mapper;
            public DeleteOrderCommandHandler(IOrderRepository orderRepoitory, IMapper mapper)
            {
                _orderRepoitory = orderRepoitory;
                _mapper = mapper;
            }

            public async Task<DeletedOrderDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                Order? order = await _orderRepoitory.GetAsync(o=>o.Id==request.Id);
                Order deletedOrder = _mapper.Map<Order>(order); 
                await _orderRepoitory.DeleteAsync(deletedOrder); 
                DeletedOrderDto result = _mapper.Map<DeletedOrderDto>(deletedOrder);
                return result;

            }
        }
    }
}
