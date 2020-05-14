using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _450Orders.Controllers
{
    public class SalespersonPerformanceController : ApiController
    {
        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IHttpActionResult GetAllSales(int id)
        {
            var orders = from entities in myOrders.Orders
                         where entities.SalesPersonID == id
                         orderby entities.Price
                         select new
                         {
                             entities.SalesPersonID,
                             entities.StoreTable.City,
                             entities.Price,
                             entities.CDTable.CDname,
                         };

            return Json(orders);
        }
    }
}
