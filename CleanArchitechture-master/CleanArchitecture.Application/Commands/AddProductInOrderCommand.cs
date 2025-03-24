using CleanArchitecture.Application.IRepository;
using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Application.Commands
{

    public class AddProductInOrderCommand : IRequest<OrderDetails>
    {
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public AddProductInOrderCommand(int orderID, OrderDetails details)
        {
            OrderId = orderID;
            ProductName = details.ProductName;
            Quantity = details.Quantity;
            Price = details.Price;
        }
        public class AddProductInOrderCommandHandler : IRequestHandler<AddProductInOrderCommand, OrderDetails>
        {
            private readonly IOrdersDetailServices _ordersDetailService;
            public AddProductInOrderCommandHandler(IOrdersDetailServices ordersDetailService)
            {
                _ordersDetailService = ordersDetailService;
            }
            public async Task<OrderDetails> Handle(AddProductInOrderCommand command, CancellationToken cancellationToken)
            {
                var orderDetal = new OrderDetails();
                orderDetal.ProductName = command.ProductName;
                orderDetal.OrderId = command.OrderId;
                orderDetal.Quantity = command.Quantity ;
                orderDetal.Price = command.Price;
                await _ordersDetailService.AddProductInOrders(orderDetal);
                return orderDetal;
            }
        }
    }
}

