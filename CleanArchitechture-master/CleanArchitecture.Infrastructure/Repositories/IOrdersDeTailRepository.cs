﻿using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public interface IOrdersDeTailRepository
    {
         Task<OrdersDetailDto> AddProductInOrders(OrderDetails orderDetail);
         Task<int> DeleteOrderDetail(int id);
    }
}
