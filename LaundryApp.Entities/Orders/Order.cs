using LaundryApp.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public  class Order : BaseObject
    {
        [Required]
        public Customer Customer { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal NetTotal { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DueDate {  get; set; }
    }

   
}
