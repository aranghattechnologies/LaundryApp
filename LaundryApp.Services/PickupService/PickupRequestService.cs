using LaundryApp.Data;
using LaundryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Services.PickupService
{
    public class PickupRequestService : IPickupRequestService
    {
        private readonly LaundryAppContext context;

        public PickupRequestService(LaundryAppContext context)
        {
            this.context = context;
        }

        public bool CreateRequest(PickUpRequest pickupRequest)
        {
            //Check if there is any on going request
            var isOnGoing = context.PickUpRequests.Any(d =>
                                d.Customer.Id == pickupRequest.Customer.Id
                                && d.Status != PickupStatus.Completed);

            if (isOnGoing)
                throw new Exception("Customer already have ongoing request");

            if (pickupRequest.PrefedTimeStart <= DateTime.UtcNow)
                throw new Exception("Cant go back and create a request from past");

            context.PickUpRequests.Add(pickupRequest);
            context.SaveChanges();

            return true;
        }

        public PickUpRequest GetPendingRequestByCustomer(long customerId)
        {
            var pendingRequests = context.PickUpRequests.FirstOrDefault(d =>
            d.Customer.Id == customerId && d.Status != PickupStatus.Completed);

            return pendingRequests;
            
        }

        public List<PickUpRequest> GetPendingRequests()
        {
           var pendingRequests = context.PickUpRequests.Where(d => d.Status != PickupStatus.Completed)
                                .ToList();

            return pendingRequests;
        }

        public bool UpdatePicupRequestStatus(PickUpRequest pickupRequest, PickupStatus status)
        {
            if (pickupRequest.Status == PickupStatus.Completed)
                throw new Exception("Cant modify a completed request");

            pickupRequest.Status = status;
            context.PickUpRequests.Update(pickupRequest);
            context.SaveChanges();

            return true;
        }
    }
}
