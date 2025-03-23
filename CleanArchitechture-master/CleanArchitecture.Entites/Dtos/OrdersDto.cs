
using CleanArchitecture.Entites.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Entites.Dtos
{ 
public class OrdersDto
    {
    public string? CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public int Status { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
}
