using LaundryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Services.PickupService
{
    public interface IPickupRequestService
    {
        /// <summary>
        /// Create a new pickup Request
        /// </summary>
        /// <param name="pickupRequest"></param>
        /// <returns></returns>
        bool CreateRequest(PickUpRequest pickupRequest);

        /// <summary>
        /// Pending Request that is not assigned
        /// </summary>
        /// <returns></returns>
        List<PickUpRequest> GetPendingRequests();

        /// <summary>
        /// Returns the pending customer request
        /// </summary>
        /// <returns>Requestif exis else return null</returns>
        PickUpRequest GetPendingRequestByCustomer(long customerId);

        /// <summary>
        /// Update the current pickup requet status
        /// </summary>
        /// <param name="pickupRequest"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        bool UpdatePicupRequestStatus(PickUpRequest pickupRequest,PickupStatus status);
    }
}
