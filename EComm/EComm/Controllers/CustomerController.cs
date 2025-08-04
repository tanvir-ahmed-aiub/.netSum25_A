using AutoMapper;
using EComm.Auth;
using EComm.DTOs;
using EComm.EF;
using EComm.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EComm.Controllers
{
    public class CustomerController : Controller
    {
        EComm_Sum25_AEntities db = new EComm_Sum25_AEntities();
        // GET: Customer

        static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order,OrderDTO>();
            });
            return new Mapper(config);
        }
        [Logged]
        public ActionResult Index()
        {
            var user = (User)Session["user"];
            var orders = (from o in db.Orders where 
                         o.CustomerId == (int)user.CustomerId
                         select o).ToList();
            //var data = nameof(OrderStatus.);
            return View(GetMapper().Map<List<OrderDTO>>(orders));
        }
    }
}