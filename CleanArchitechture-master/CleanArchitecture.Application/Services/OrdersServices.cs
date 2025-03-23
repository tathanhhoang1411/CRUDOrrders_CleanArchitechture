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

        public Task<List<OrdersDto>> GetList_Products(int skip, int take, string data)
        {
            return _ordersRepository.GetListOrders(skip, take, data);
        }

        public Task<int> Orders_InsertUpdate(Orders orders)
        {
            return _ordersRepository.CreateOrders(orders);
        }
    }
}
