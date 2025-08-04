using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EComm.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public System.DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public double Total { get; set; }
    }
}