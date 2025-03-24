using AutoMapper;
using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using CleanArchitecture.Entites.Interfaces;
using CleanArchitecture.Infrastructure.DBContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CleanArchitecture.Infrastructure.Repositories
{
    public class OrdersDetailRepository : IOrdersDeTailRepository
    {
        private ApplicationContext _userContext;
        private readonly IMapper _mapper;
        public OrdersDetailRepository(ApplicationContext userContext, IMapper mapper)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrdersDetailDto> AddProductInOrders(OrderDetails createOrdersDetail)
        {
            _userContext.Add(createOrdersDetail);
             _userContext.SaveChanges();
            return _mapper.Map<OrdersDetailDto>(createOrdersDetail);
        }
        public async Task<int> DeleteOrderDetail(int id)
        {

            var orderDetailInDB = _userContext.Orders
                .Where(p => p.Id == id).AsNoTracking().ToList();
            if (orderDetailInDB.Count > 0)
            {
                // Gọi stored procedure
                var parameter = new SqlParameter("@OrderDetailId", id);
                var result = _userContext.Database.ExecuteSqlRaw("EXEC DeleteOrderDetail @OrderDetailId", parameter);
                if (result > 0)
                {
                    return id;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }
    }
}
