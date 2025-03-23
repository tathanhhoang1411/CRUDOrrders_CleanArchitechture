using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Query
{
    public class Get1OrdersQuery : IRequest<OrdersDto>
    {
            
        public int Id { get; set; }

        public Get1OrdersQuery(int id)
        {
            Id = id;
        }
    }

    public class Get1OrdersQueryHandler : IRequestHandler<Get1OrdersQuery, OrdersDto>
        {

            private readonly IOrdersRepository _ordersRepository;
            public Get1OrdersQueryHandler(IOrdersRepository ordersRepository)
            {
                _ordersRepository = ordersRepository;
            }
            public async Task<OrdersDto> Handle(Get1OrdersQuery query, CancellationToken cancellationToken)
            {
                var ordersList = await _ordersRepository.Get1Orders(query.Id);
            return ordersList ?? new OrdersDto(); // Trả về danh sách rỗng nếu không có sản phẩm
            }
        }
    }

