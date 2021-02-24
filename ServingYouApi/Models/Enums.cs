using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Models
{  
    public enum OrderMethods
    {
        Web,
        Mobile,
        Telephone,
    }

    public enum OrderStatus
    {
        Confirmed,
        Ready,
        Completed
    }  
}
