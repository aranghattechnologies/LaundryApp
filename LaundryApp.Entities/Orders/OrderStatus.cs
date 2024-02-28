using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Entities.Orders
{
    public enum OrderStatus
    {
        Created =1,
        PaymentPending =2,
        PaymentCompleted= 3,
        PaymentFailed = 4,
        InProgress,
        ReadyForDelivery,
        OutForDelivery,
        Delivered,
        Completed
    }
}
