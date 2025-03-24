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

    public class DeleteOrderDetailByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteOrderDetailByIdCommand(int id)
        {
            Id = id;
        }
        public class DeleteOrderDetailByIdCommandHandler : IRequestHandler<DeleteOrderDetailByIdCommand, int>
        {
            private readonly IOrdersDetailServices _ordersDetailService;
            public DeleteOrderDetailByIdCommandHandler(IOrdersDetailServices ordersDetailService)
            {
                _ordersDetailService = ordersDetailService;
            }
            public async Task<int> Handle(DeleteOrderDetailByIdCommand command, CancellationToken cancellationToken)
            {

                int result=await _ordersDetailService.DeleteOrderDetail(command.Id);
                if (result == 0)
                {
                    return 0;
                }
                return command.Id;
            }
        }
    }
}
    
