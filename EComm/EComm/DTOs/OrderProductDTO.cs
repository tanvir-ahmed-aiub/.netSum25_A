using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EComm.DTOs
{
    public class OrderProductDTO : OrderDTO
    {
        public List<OrderDetailDTO> OrderDetails { get; set; }
        public OrderProductDTO() {
            OrderDetails = new List<OrderDetailDTO>();
        }
    }
}