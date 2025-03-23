
using CleanArchitecture.Entites.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Entites.Dtos
{ 
public class OrdersDetailDto
    {
        public int OrderId { get; set; }
        public string  ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
