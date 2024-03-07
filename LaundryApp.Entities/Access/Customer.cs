using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities
{
    public class Customer : User
    {
        [Required]
        public string Phone {  get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public string? PasswordResetToken { get; set; }

        public DateTime? PasswordTokenExpiry { get; set; }

        public string ProfilePicture { get; set; }
    }
}
