using LaundryApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.laundryapp.com.Controllers.Customers
{
    [ApiController]
    [Route("api/customer/signup")]
    public class CustomerSignUpController : ControllerBase
    {
        ICustomerAccessService customerAccessService;

        public CustomerSignUpController(ICustomerAccessService customerAccessService)
        {
            this.customerAccessService = customerAccessService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            SignUpRequest request = JsonSerializer.Deserialize<SignUpRequest>(
                                            HttpContext.Request.Form["data"]);

            if(HttpContext.Request.Form.Files.Count > 0)
            {
                request.Photo = HttpContext.Request.Form.Files[0];
            }

            var customer = customerAccessService.SignUp(request);

            return Ok(customer);
        }
    }
}
