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

    public class UpdateOrderCommand : IRequest<Orders>
    {
        public string? CustomerName { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
        public UpdateOrderCommand(int id, string customerName, int status)
        {
            Id = id;
            Status = status;
            CustomerName = customerName;
        }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Orders>
        {
            private readonly IOrdersRepository _ordersRepository;
            public UpdateOrderCommandHandler(IOrdersRepository ordersRepository)
            {
                _ordersRepository = ordersRepository;
            }
            public async Task<Orders> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                DateTime now =DateTime.UtcNow;
                var order = new Orders();
                order.CustomerName = command.CustomerName;
                order.Status = command.Status;
                order.Id = command.Id;
                order.UpdatedAt = now;
                await _ordersRepository.UpdateOrders(order);
                return order;
            }
        }
    }
}
    
