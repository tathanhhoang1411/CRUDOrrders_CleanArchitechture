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
        [Range(0, 2, ErrorMessage = "Status must be 0: Pending, 1: Completed, or 2: Canceled.")]
        public int Status { get; set; } // Có thể thêm validation cho Status nếu cần

        [Required]
        [Range(0,2, ErrorMessage = "Status must be 0: Pending, 1: Completed, or 2: Canceled.")]
        private DateTime _createAt;

        [Required]
        public DateTime CreateAt
        {
            get => _createAt;
            set
            {
                if (value < new DateTime(1, 1, 1) || value > DateTime.Now)
                {
                    throw new ArgumentException("CreateAt must be between 01/01/0001 and today.");
                }
                _createAt = value;
            }
        }

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
