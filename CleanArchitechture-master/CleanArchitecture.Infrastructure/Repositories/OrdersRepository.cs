using AutoMapper;
using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using CleanArchitecture.Entites.Interfaces;
using CleanArchitecture.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CleanArchitecture.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private ApplicationContext _userContext;
        private readonly IMapper _mapper;
        public OrdersRepository(ApplicationContext userContext, IMapper mapper)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateOrders(Orders createOrders)
        {
            _userContext.Add(createOrders);
            return _userContext.SaveChanges();
        }

        public async Task<List<OrdersDto>> GetListOrders(int skip, int take, string data)
        {

            var orders = await _userContext.Orders
                .Where(p => p.CustomerName.Contains(data))
                .Skip(skip)
                .Take(take)
                .OrderBy(p => p.CreateAt)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<OrdersDto>>(orders);


        }     
        public async Task<List<OrdersDetailDto>> GetListOrdersDetail(int idOrders,int skip, int take, string data)
        {

            var ordersDetail = (from orderdetails in _userContext.OrderDetails
                               join order in _userContext.Orders on orderdetails.OrderId equals order.Id
                               where order.Id == idOrders && orderdetails.ProductName.ToLower().Contains(data.ToLower())
                               select orderdetails)
                               .Skip(skip) // Bỏ qua số bản ghi đã chỉ định
                    .Take(take); 
            ; // Lấy OrderDetails

            var result = ordersDetail.ToList();
            return _mapper.Map<List<OrdersDetailDto>>(result);


        }    
        public async Task<OrdersDto> Get1Orders(int id)
        {

            var orders = await _userContext.Orders
               .Where(p => p.Id == id)
               .AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<OrdersDto>(orders);


        }      
        
        public async Task<OrdersDto> UpdateOrders(Orders order)
        {

            var orderInDB = await _userContext.Orders
               .FindAsync(order.Id);
            if (orderInDB != null)
            {
                // Cập nhật thông tin
                orderInDB.CustomerName = order.CustomerName;
                orderInDB.Status = order.Status;

                // Lưu thay đổi vào cơ sở dữ liệu
                _userContext.SaveChanges();
            }

            return _mapper.Map<OrdersDto>(orderInDB);


        }
    }
}
