using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IRepository
{
    public interface IOrdersServices
    {
        Task<List<OrdersDto>> GetList_Products(int skip, int take, string data);
        Task<int> Orders_InsertUpdate(Orders orders);
    }
}
