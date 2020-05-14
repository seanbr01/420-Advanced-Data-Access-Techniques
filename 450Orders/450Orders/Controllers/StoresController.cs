using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _450Orders.Controllers
{
    public class StoresController : ApiController
    {
        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IHttpActionResult GetAllStores()
        {
            var orders = from entities in myOrders.StoreTables
                         select new
                         {
                             entities.StoreNumberID,
                             entities.City,
                             entities.State,
                             entities.NumberEmployees,
                         };

            return Json(orders);
        }
    }
}
