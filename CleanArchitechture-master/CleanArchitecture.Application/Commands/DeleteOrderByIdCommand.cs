using CleanArchitecture.Application.IRepository;
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

    public class DeleteOrderByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteOrderByIdCommand(int id)
        {
            Id = id;
        }
        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, int>
        {
            private readonly IOrdersServices _ordersService;
            public DeleteOrderByIdCommandHandler(IOrdersServices ordersService)
            {
                _ordersService = ordersService;
            }
            public async Task<int> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
            {

                int result=await _ordersService.DeleteOrder(command.Id);
                if (result == 0)
                {
                    return 0;
                }
                return command.Id;
            }
        }
    }
}
    
