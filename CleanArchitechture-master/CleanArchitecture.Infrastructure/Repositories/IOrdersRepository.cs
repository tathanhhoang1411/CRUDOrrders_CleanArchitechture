using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public interface IOrdersRepository
    {
        Task<int> CreateOrders(Orders createOrders);
        Task<List<OrdersDto>> GetListOrders(int skip, int take, string data);
        Task<List<OrdersDetailDto>> GetListOrdersDetail(int idOrders,int skip, int take, string data);
        Task<OrdersDto> Get1Orders(int id);
        Task<OrdersDto> UpdateOrders(Orders order);
    }
}
