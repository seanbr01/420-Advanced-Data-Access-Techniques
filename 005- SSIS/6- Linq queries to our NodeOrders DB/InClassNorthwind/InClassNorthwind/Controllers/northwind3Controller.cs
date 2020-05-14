using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InClassNorthwind.Controllers
{
    public class northwind3Controller : ApiController
    {
        northwindEntities myEntities = new northwindEntities();

        public IHttpActionResult GetQ3()
        {
            DateTime someDate = new DateTime(1998, 05, 01);
            // going from 1 order_detail to one unique Order
            var ProductCollection3 = from oneOrderDetail in myEntities.Order_Details
                                     where oneOrderDetail.Discount > 0 && oneOrderDetail.Order.ShippedDate > someDate
                                     orderby oneOrderDetail.Order.ShippedDate ascending 
                                     select new
                                     {
                                         oneOrderDetail.OrderID,
                                         oneOrderDetail.Product.ProductName,
                                         oneOrderDetail.Discount,
                                         oneOrderDetail.Order.OrderDate,
                                         oneOrderDetail.Order.ShippedDate,
                                         oneOrderDetail.Order.ShipCity
                                     };
            return Json(ProductCollection3);

        }
    }
}
