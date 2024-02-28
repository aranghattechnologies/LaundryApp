using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Service Service { get; set; }

        [Required]
        public int Qty { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal LineTotal { get; set; }
    }
}
