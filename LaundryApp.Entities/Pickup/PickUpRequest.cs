using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public class PickUpRequest : BaseObject
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public DateTime? PrefedTimeStart { get; set; }

        [Required]
        public DateTime? PrefedTimeEnd { get; set; }

        [Required]
        public PickupStatus Status { get; set; } = PickupStatus.Pending;

        public Employee? AssignedTo {  get; set; }

        public DateTime? PickUpTime {  get; set; }
    }
}
