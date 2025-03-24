using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IRepository
{
    public interface IOrdersDetailServices
    {
        Task<OrdersDetailDto> AddProductInOrders(OrderDetails createOrdersDetail);
        Task<int> DeleteOrderDetail(int id);
    }
}
