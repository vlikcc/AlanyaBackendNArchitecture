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

namespace Application.Features.Orders.Commands.Create
{
    public class CreateOrderCommand:IRequest<CreatedOrderDto>
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }        
       

        public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,CreatedOrderDto>
        {
            private readonly IOrderRepository _orderRepositorry;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IOrderRepository orderRepositorry, IMapper mapper)
            {
                _orderRepositorry = orderRepositorry;
                _mapper = mapper;
            }

            public async Task<CreatedOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                Order order = _mapper.Map<Order>(request);
                order.OrderDate = System.DateTime.Now;
                order.OrderStatus = false;
                Order createdOrder =  await _orderRepositorry.AddAsync(order);
                CreatedOrderDto result = _mapper.Map<CreatedOrderDto>(createdOrder);
                return result;
            }
        }
    }
}
