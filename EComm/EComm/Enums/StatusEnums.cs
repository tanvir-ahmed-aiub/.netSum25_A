using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EComm.Enums
{
    public enum OrderStatus  {
        OrderPlaced = 1,
        Processing,
        CancelledByUser,
        CancelledByAdmin,
        OnTheWay,
        Delivered


    }
    public class StatusEnums
    {
    }
}