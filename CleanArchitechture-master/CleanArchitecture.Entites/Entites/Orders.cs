using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Entites.Entites
{
    public class Orders
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be greater than zero.")]
        public decimal TotalAmount { get; set; }

        [Required]
        public int Status { get; set; } // Có thể thêm validation cho Status nếu cần

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Constructor
        public Orders( string customerName, decimal totalAmount, int status,DateTime Createat,DateTime Updateat)
        {
            CustomerName = customerName;
            TotalAmount = totalAmount;
            Status = status;
            CreateAt = Createat;
            UpdatedAt = Updateat;
        }

        public Orders()
        {
        }
    }
}
