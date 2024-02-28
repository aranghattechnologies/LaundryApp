using LaundryApp.Data;
using LaundryApp.Services;

namespace LaundryServicesTest
{
    public class CustomerAccessServiceTest
    {
        LaundryAppContext context = new LaundryAppContext();
        ICustomerAccessService customerAccessService;

        [SetUp]
        public void Setup()
        {
            customerAccessService = new CustomerAccessService(context);
        }

        [Test]
        public void ValidSignUpRequest_ValidValues_ReturnsCustomer()
        {
            var signUpRequest = new SignUpRequest();
            signUpRequest.Name = "Sreehari";
            signUpRequest.Email = "sreehariis@gmail.com";
            signUpRequest.Password = "abcd@1234";

            var custoemr = customerAccessService.SignUp(signUpRequest);

            Assert.IsNotNull(custoemr);
            Assert.IsTrue(custoemr.Id > 0);
        }

        [Test]
        public void DuplicateEmail_ThrowsDuplicateEmailException()
        {
            var signUpRequest = new SignUpRequest();
            signUpRequest.Name = "Sreehari";
            signUpRequest.Email = "sreehariis@gmail.com";
            signUpRequest.Password = "abcd@1234";

            Assert.Throws<DuplicateEmailException>(() => customerAccessService.SignUp(signUpRequest));

        }
    }
}