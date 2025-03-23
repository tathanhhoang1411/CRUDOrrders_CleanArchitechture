using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Entites.Entites
{
    public class OrderDetails
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        // Constructor
        public OrderDetails( int orderId, string productName, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
        public OrderDetails()
        {

        }
    }
}
