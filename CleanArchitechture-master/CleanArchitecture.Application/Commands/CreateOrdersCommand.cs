using CleanArchitecture.Entites.Entites;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands
{

    public class CreateOrdersCommand : IRequest<Orders>
    {
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTime Createat { get; set; }
        public DateTime Updateat { get; set; }
        public class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand, Orders>
        {
            private readonly IOrdersRepository _ordersRepository;
            public CreateOrdersCommandHandler(IOrdersRepository ordersRepository)
            {
                _ordersRepository = ordersRepository;
            }
            public async Task<Orders> Handle(CreateOrdersCommand command, CancellationToken cancellationToken)
            {
                var order = new Orders();
                order.CustomerName = command.CustomerName;
                order.TotalAmount = command.TotalAmount;
                order.Status = command.Status;
                order.CreateAt = command.Createat;
                order.UpdatedAt = command.Updateat;
                await _ordersRepository.CreateOrders(order);
                return order;
            }
        }
    }
}
    
