using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InClassNorthwind.Controllers
{
    public class northwind2Controller : ApiController
    {
        northwindEntities myEntities = new northwindEntities();


        public IHttpActionResult GetQ2()
        {
            //  show all orderID where orderdetail unit price > 100  with productName
            // using nav prop to go from 1 orderDetail (of many) to 1 Order.ShipName
            var ProductCollection2 = from oneOrderDetail in myEntities.Order_Details
                                     where (oneOrderDetail.Quantity * oneOrderDetail.UnitPrice) > 8000
                                     orderby oneOrderDetail.OrderID ascending
                                     select new
                                     {
                                         oneOrderDetail.OrderID,
                                         oneOrderDetail.Quantity,
                                         oneOrderDetail.UnitPrice,
                                         oneOrderDetail.Order.ShipName
                                     };
            return Json(ProductCollection2);
        }
    }
}
