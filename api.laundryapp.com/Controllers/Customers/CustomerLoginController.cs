using LaundryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.laundryapp.com.Controllers.Customers
{
    [Route("api/customer/login")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly ICustomerAccessService customerAccessService;

        public CustomerLoginController(ICustomerAccessService customerAccessService)
        {
            this.customerAccessService = customerAccessService;
        }

        [HttpPost]
        public IActionResult Post(SignInRequest request) {
            try
            {
                var claims = this.customerAccessService.SignIn(request);
                //Create JWT and Sent
                return Ok();
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
