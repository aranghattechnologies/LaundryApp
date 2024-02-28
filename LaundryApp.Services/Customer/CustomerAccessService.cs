using LaundryApp.Data;
using LaundryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Services
{
    public class CustomerAccessService : ICustomerAccessService
    {
        private readonly LaundryAppContext context;

        public CustomerAccessService(LaundryAppContext context)
        {
            this.context = context;
        }

        public List<Claim> SignIn(SignInRequest request)
        {
            var customer = context.Customers.FirstOrDefault(d => d.Email == request.Email 
                                        && d.Password == request.Password);

            if (customer == null)
                throw new AuthenticationException("Login Failed");

            var result = new List<Claim> {
                new Claim("Email",customer.Email),
                new Claim(ClaimTypes.NameIdentifier,customer.Name),
            };

            return result;
        }

        public Customer SignUp(SignUpRequest request)
        {
            //Check if the email is already in use
            if (context.Customers.Any(d => d.Email == request.Email))
                throw new DuplicateEmailException("Email already exist");

            var customer = new Customer();
            customer.Email = request.Email;
            customer.Longitude = 0;
            customer.Latitude = 0;
            customer.Phone = "0";
            customer.Address = "Not Updated";
            customer.CreatedDate = DateTime.UtcNow;
            customer.Name = request.Name;
            customer.Password = request.Password;

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;

        
        }
    }
}
