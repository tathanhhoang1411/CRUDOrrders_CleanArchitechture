using AutoMapper;
using CleanArchitecture.Application.IRepository;
using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using CleanArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository
{
    public class OrdersDetailService : IOrdersDetailServices
    {
        private readonly IOrdersDeTailRepository _ordersDeTailRepository;
        private readonly IMapper _mapper;
        public OrdersDetailService(IOrdersDeTailRepository ordersDeTailRepository)
        {
            _ordersDeTailRepository = ordersDeTailRepository ?? throw new ArgumentNullException(nameof(ordersDeTailRepository));
        }

        public Task<OrdersDetailDto> AddProductInOrders(OrderDetails createOrdersDetail)
        {
            return _ordersDeTailRepository.AddProductInOrders(createOrdersDetail);
        }     
        public Task<int> DeleteOrderDetail(int id)
        {
            return _ordersDeTailRepository.DeleteOrderDetail(id);
        }

    }
}
