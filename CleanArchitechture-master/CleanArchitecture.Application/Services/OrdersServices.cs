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
    public class OrdersServices : IOrdersServices
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        public OrdersServices(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        }

        public Task<List<OrdersDto>> GetListOrders(int skip, int take, string data)
        {
            return _ordersRepository.GetListOrders(skip, take, data);
        }
        public Task<List<OrdersDetailDto>> GetListOrdersDetail(int idOrders, int skip, int take, string data)
        {
            return _ordersRepository.GetListOrdersDetail(idOrders,skip,take,data);
        }
        public Task<int> CreateOrders(Orders orders)
        {
            return _ordersRepository.CreateOrders(orders);
        }
        public Task<OrdersDto> Get1Orders(int id)
        {
            return _ordersRepository.Get1Orders(id);
        }
       public Task<OrdersDto> UpdateOrders(Orders order)
        {
            return _ordersRepository.UpdateOrders(order);
        }     
        
        public Task<int> DeleteOrder(int id)
        {
             _ordersRepository.DeleteOrders(id);
            return Task.FromResult(id);
        }

    }
}
