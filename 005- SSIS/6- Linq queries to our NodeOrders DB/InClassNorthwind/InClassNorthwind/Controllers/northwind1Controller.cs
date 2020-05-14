using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InClassNorthwind.Controllers
{
    public class northwind1Controller : ApiController
    {
        northwindEntities myEntities = new northwindEntities();


        public IHttpActionResult GetQ1()
        {
            // show all orderID where orderdetail unit price > 100  with productName
            // going from 1 order_detail to one unique Product
            var ProductCollection1 = from oneOrderDetail in myEntities.Order_Details
                                     where (oneOrderDetail.Quantity * oneOrderDetail.UnitPrice) > 6000
                                     orderby oneOrderDetail.Quantity ascending
                                     select new
                                     {
                                         oneOrderDetail.OrderID,
                                         oneOrderDetail.Quantity,
                                         oneOrderDetail.UnitPrice,
                                         oneOrderDetail.Product.ProductName
                                     };
            return Json(ProductCollection1);
        }



      


    }
}

