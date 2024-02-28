using LaundryApp.Entities.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public class Employee : User
    {
        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public string Phone { get; set; }

        [Required]
        public RoleType Role { get; set; } = RoleType.NonAdmin;

        [Required]
        public bool IsActive { get; set; } = false;
    }
}
