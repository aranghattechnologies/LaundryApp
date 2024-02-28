using LaundryApp.Data;
using LaundryApp.Entities;
using LaundryApp.Services;
using LaundryApp.Services.PickupService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryServicesTest
{
    public class PickupRequestTests
    {
        LaundryAppContext context = new LaundryAppContext();
        IPickupRequestService pickupRequestService;

        [SetUp]
        public void Setup()
        {
            pickupRequestService = new PickupRequestService(context);
        }

        [Test]
        public void CreateRequest_ValidValue_ReturnsTrue()
        {
            var pickupRequest = new PickUpRequest();
            pickupRequest.Status = PickupStatus.Pending;
            pickupRequest.CreatedDate = DateTime.UtcNow;
            pickupRequest.Customer = context.Customers.First();
            pickupRequest.PrefedTimeStart = DateTime.UtcNow.AddHours(1);
            pickupRequest.PrefedTimeEnd = DateTime.UtcNow.AddDays(1);

            var r = pickupRequestService.CreateRequest(pickupRequest);

            Assert.IsTrue(r);

        }

        [Test]
        public void CreateRequest_PendingRequest_ThrowsException()
        {
            var pickupRequest = new PickUpRequest();
            pickupRequest.Status = PickupStatus.Pending;
            pickupRequest.CreatedDate = DateTime.UtcNow;
            pickupRequest.Customer = context.Customers.First(d =>d.Email == "abcd@gmail.com");
            pickupRequest.PrefedTimeStart = DateTime.UtcNow.AddHours(1);
            pickupRequest.PrefedTimeEnd = DateTime.UtcNow.AddDays(1);

            Assert.Throws<Exception>(() => pickupRequestService.CreateRequest(pickupRequest));

        }
    }
}
