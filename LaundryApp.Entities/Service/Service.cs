using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public class Service : BaseObject
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public ServiceUnit Unit { get; set; }

        [Required]
        public decimal PerUnitPrice { get; set; }

    }
}
