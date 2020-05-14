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
        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IHttpActionResult GetAllOrders()
        {
            myOrders.Configuration.ProxyCreationEnabled = false;
            return Json(myOrders.Orders);

            //var orders = from entities in myOrders.Orders
            //             select new
            //             {
            //                 OrdersID = entities.OrdersID,
            //                 StoreNumberID = entities.StoreNumberID,
            //                 SalesPersonID = entities.SalesPersonID,
            //                 CdID = entities.CdID,
            //                 Price = entities.Price,
            //                 Datetime = entities.Datetime
            //             };
            //return orders.ToList();


            //return myOrders.Orders.ToList();
        }

        public IHttpActionResult GetOrder(int id)
        {
            //var order = myOrders.Orders.FirstOrDefault((o) => o.OrdersID == id);
            //if (order == null)
            //{
            //    return NotFound();
            //}
            //return Ok(order);

            var orders = from entities in myOrders.Orders
                         where entities.OrdersID == id
                         select new
                         {
                             OrdersID = entities.OrdersID,
                             StoreNumberID = entities.StoreNumberID,
                             SalesPersonID = entities.SalesPersonID,
                             CdID = entities.CdID,
                             Price = entities.Price,
                             Datetime = entities.Datetime
                         };
            return Json(orders);

            //var orders = from entities in myOrders.Orders
            //             where entities.OrdersID == id
            //             select new
            //             {
            //                 entities.OrdersID,
            //                 entities.StoreNumberID,
            //                 entities. SalesPersonID,
            //                 entities.CdID,
            //                 entities.Price,
            //                 entities.Datetime
            //             };

            //return Json(orders);
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
