using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EComm.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OId { get; set; }
        public int PId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}