using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InClassNorthwind.Controllers
{
    public class northwind5Controller : ApiController
    {
 
        northwindEntities myEntities = new northwindEntities();

        public IHttpActionResult GetQ5()
        {
            //  Using LINQ join  (from from) to do a one (Product) to many (Order_Details).  One Product can be on many orders
            var ProductCollection5 = from oneProduct in myEntities.Products
                                     from oneOrderDetail in myEntities.Order_Details
                                     
                                     where oneOrderDetail.Quantity > 80 && oneOrderDetail.ProductID == oneProduct.ProductID
                                     orderby oneProduct.ProductName ascending
                                     select new
                                     {
                                         oneOrderDetail.OrderID,
                                         oneOrderDetail.Quantity,
                                         oneOrderDetail.UnitPrice,
                                         oneProduct.ProductName,
                                         oneProduct.UnitsInStock
                                     };

            // this one can not be done using Nav properties, they cannot do many to one 
            // one object can hold a pointer to one other object, but really ugly to have one object 
            // hold a pointer to 17, or 4231 other objects, and constantly changing.

            return Json(ProductCollection5);
        }
    }
}
