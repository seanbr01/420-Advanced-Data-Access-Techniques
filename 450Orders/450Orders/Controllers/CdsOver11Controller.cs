using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _450Orders.Controllers
{
    public class CdsOver11Controller : ApiController
    {
        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IHttpActionResult GetAllOrders()
        {
            var orders = from entities in myOrders.Orders
                         where entities.Price > 11
                         orderby entities.StoreTable.City, entities.CDTable.CDname
                         select new
                         {
                             entities.StoreTable.City,
                             entities.CDTable.CDname,
                             entities.Price,
                         };

            return Json(orders);
        }
    }
}
