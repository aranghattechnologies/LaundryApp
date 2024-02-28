using LaundryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Services
{
    public interface ICustomerAccessService
    {
        /// <summary>
        /// Signup Request for a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Customer</returns>
        /// <exception cref="ArgumentNullException">When the request is null</exception>
        Customer SignUp(SignUpRequest request);


        /// <summary>
        /// Try to sign in a customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of claims</returns>
        /// <exception cref="AuthenticationException"></exception>
        List<Claim> SignIn(SignInRequest request);
    }
}
