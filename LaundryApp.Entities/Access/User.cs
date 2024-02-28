using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public abstract class User : BaseObject
    {
        /// <summary>
        /// Name of the user including first name and last name
        /// </summary>
        [Required]
        [RegularExpression("^[a-zA-Z ]{2,50}$")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Password { get; set; }


    }
}
