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

namespace Application.Features.Orders.Commands.Update
{
    public class UpdateOrderCommand:IRequest<UpdatedOrderDto>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public List<Product> Products { get; set; }

        public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommand,UpdatedOrderDto>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                Order? order = await _orderRepository.GetAsync(o=>o.Id==request.Id);
                order.Products = request.Products;
                order.CustomerId = request.CustomerId;
                order.EmployeeId = request.EmployeeId;
                Order mappedOrder = _mapper.Map<Order>(order);
                Order updatedOrder = await _orderRepository.UpdateAsync(mappedOrder);
                UpdatedOrderDto result = _mapper.Map<UpdatedOrderDto>(updatedOrder);
                return result;

            }
        }
    }
}
