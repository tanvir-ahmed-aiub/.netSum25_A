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
    public class OrderController : Controller
    {
        EComm_Sum25_AEntities db= new EComm_Sum25_AEntities();

        Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product,ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        // GET: Order
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            var products = GetMapper().Map<List<ProductDTO>>(data);
            return View(products);
        }
        public ActionResult AddToCart(int id) {
            var p = db.Products.Find(id);
            var pr = GetMapper().Map<ProductDTO>(p);
            pr.Qty = 1;

            List<ProductDTO> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else {
                cart = (List<ProductDTO>)Session["cart"];
            }
            cart.Add(pr);
            Session["cart"] = cart;
            
            
            return RedirectToAction("Index");

        }

        public ActionResult Increase(int id) {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty++;
            
            return RedirectToAction("ShowCart");

        }

        public ActionResult Decrease(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty--;
            return RedirectToAction("ShowCart"); ;
        }

        public ActionResult ShowCart() {
            if (Session["cart"] == null)
            {
                TempData["Msg"] = "Cart is Empty";
                return RedirectToAction("Index");
            }
            
            var cart = (List<ProductDTO>)Session["cart"];
            return View(cart);
        }
        [HttpPost]
        [Logged]
        public ActionResult PlaceOrder(double gTotal) {

            var user = (User)Session["User"];
            var order = new Order() { 
                Total = gTotal,
                CustomerId = (int)user.CustomerId,
                StatusId = (int) OrderStatus.OrderPlaced,
                Date = DateTime.Now,
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var cart = (List<ProductDTO>)Session["cart"];
            foreach (var item in cart)
            {
                var od = new OrderDetail() { 
                    PId = item.Id,
                    Qty = item.Qty,
                    Price = item.Price,
                    OId = order.Id
                };
                db.OrderDetails.Add(od);
            }
            db.SaveChanges();
            Session["cart"] = null;
            return RedirectToAction("Index");
        }
    }
}