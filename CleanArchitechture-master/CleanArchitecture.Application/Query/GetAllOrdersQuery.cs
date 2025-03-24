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

namespace CleanArchitecture.Application.Query
{
    public class GetAllOrdersQuery : IRequest<List<OrdersDto>>
    {
            
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Data { get; set; }

        public GetAllOrdersQuery(int skip, int take, string data)
        {
            Skip = skip;
            Take = take;
            Data = data;
        }
    }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrdersDto>>
        {

            private readonly IOrdersServices _ordersService;
            public GetAllOrdersQueryHandler(IOrdersServices ordersService)
            {
            _ordersService = ordersService;
            }
            public async Task<List<OrdersDto>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var ordersList = await _ordersService.GetListOrders(query.Skip, query.Take, query.Data);
            return ordersList ?? new List<OrdersDto>(); // Trả về danh sách rỗng nếu không có sản phẩm
            }
        }
    }

