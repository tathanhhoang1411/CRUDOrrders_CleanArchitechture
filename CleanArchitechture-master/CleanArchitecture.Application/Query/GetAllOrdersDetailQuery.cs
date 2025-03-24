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
    public class GetAllOrdersDetailQuery : IRequest<List<OrdersDetailDto>>
    {
            
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Data { get; set; }
        public int IDOrders { get; set; }

        public GetAllOrdersDetailQuery(int idOrders, int skip, int take, string data)
        {
            Skip = skip;
            Take = take;
            Data = data;
            IDOrders = idOrders;
        }
    }

    public class GetAllOrdersDetailQueryHandler : IRequestHandler<GetAllOrdersDetailQuery, List<OrdersDetailDto>>
        {

            private readonly IOrdersServices _ordersServices;
            public GetAllOrdersDetailQueryHandler(IOrdersServices ordersServices)
            {
            _ordersServices = ordersServices;
            }
            public async Task<List<OrdersDetailDto>> Handle(GetAllOrdersDetailQuery query, CancellationToken cancellationToken)
            {
                var ordersDetailList = await _ordersServices.GetListOrdersDetail(query.IDOrders,query.Skip, query.Take, query.Data);
            return ordersDetailList ?? new List<OrdersDetailDto>(); // Trả về danh sách rỗng nếu không có sản phẩm
            }
        }
    }

