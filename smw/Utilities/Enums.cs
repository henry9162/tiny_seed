using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Utilities
{
    public enum Role
    {
        Customer = 1,
        Merchant = 2,
        Admin = 3,
        SuperAdmin = 4
    }

    public enum CustomRequestType
    {
        Self = 1,
        ThirdParty = 2
    }

    public enum CustomRequestStatus
    {
        Pending = 1,
        Accepted = 2,
        InProgress = 3,
        Completed = 4,
        Dispatched = 5,
        Delivered = 6
    }

    public enum PaymentStatus
    {
        Success = 1,
        Failed = 2,
        Pending = 3
    }
}