using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _450Orders.Controllers
{
    public class StorePerformanceController : ApiController
    {
        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IHttpActionResult GetStoreSales(int id)
        {
            var orders = from storeEntities in myOrders.StoreTables
                         from orderEntities in myOrders.Orders

                         where storeEntities.StoreNumberID == id && orderEntities.StoreNumberID == storeEntities.StoreNumberID

                         orderby orderEntities.Price, orderEntities.Datetime
                         select new
                         {
                             storeEntities.City,
                             orderEntities.Price,
                             orderEntities.Datetime,
                         };

            return Json(orders);
        }
    }
}
