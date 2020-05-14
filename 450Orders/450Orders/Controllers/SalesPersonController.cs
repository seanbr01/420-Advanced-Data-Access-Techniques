using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _450Orders.Controllers
{
    public class SalesPersonController : ApiController
    {
        NodeOrdersEntities myOrders = new NodeOrdersEntities();

        public IHttpActionResult GetAllPeople()
        {
            var orders = from entities in myOrders.SalesPersonTables
                         select new
                         {
                             entities.SalesPersonID,
                             entities.FirstName,
                             entities.LastName,
                             entities.Age,
                             entities.StoreNumberID,
                         };

            return Json(orders);
        }
    }
}
