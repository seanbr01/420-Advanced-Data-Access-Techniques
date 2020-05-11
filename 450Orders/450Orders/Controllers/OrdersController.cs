
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace _450Orders.Controllers
{
    public class OrdersController : ApiController
    {
        //Order[] orders = new Order[]
        //{
        //    new Order { ID = 1, StoreNumberID = 1, SalesPersonID = 1, CdID = 1, Price = 5, Datetime = DateTime.Now },
        //    new Order { ID = 2, StoreNumberID = 2, SalesPersonID = 2, CdID = 2, Price = 10, Datetime = DateTime.Now },
        //    new Order { ID = 3, StoreNumberID = 3, SalesPersonID = 3, CdID = 3, Price = 15, Datetime = DateTime.Now }
        //};

        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IEnumerable<Order> GetAllOrders()
        {
            return myOrders.Orders.ToList();
        }

        public IHttpActionResult GetOrder(int id)
        {
            var order = myOrders.Orders.FirstOrDefault((o) => o.OrdersID == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IHttpActionResult Save(Order order)
        {
            //orders.Order.Add(order);
            //orders.SaveChanges();
            return Ok();
        }

        public HttpResponseMessage Delete(int id)
        {
            bool found = true;
            //string subject = id;
            Order order = myOrders.Orders.FirstOrDefault((o) => o.OrdersID == id);
            if (order != null)
            {
                myOrders.Orders.Remove(order);
                myOrders.SaveChanges();
            }
            else
            {
                found = false;
            }
            HttpResponseMessage response = new HttpResponseMessage();
            if (!found)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
        }
    }
}
