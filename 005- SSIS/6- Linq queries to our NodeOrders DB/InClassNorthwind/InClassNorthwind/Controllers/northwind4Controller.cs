using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InClassNorthwind.Controllers
{
    public class northwind4Controller : ApiController
    {
        northwindEntities myEntities = new northwindEntities();

        public IHttpActionResult GetQ4()
        {
            //  Using LINQ join  (from from)  this gets a CROSS JOIN (AKA Cartesian Product).
            // to do an each (order detail) to every (Products).  One Order MAY have many Products

            var ProductCollection4 = from oneOrderDetail in myEntities.Order_Details
                                     from oneProduct in myEntities.Products
                                     where oneOrderDetail.Quantity > 80 //  && oneOrderDetail.ProductID == oneProduct.ProductID
                                     orderby oneOrderDetail.OrderID ascending
                                     select new
                                     {
                                         oneOrderDetail.OrderID,
                                         oneOrderDetail.Quantity,
                                         oneOrderDetail.UnitPrice,
                                         oneProduct.ProductName,
                                         oneProduct.UnitsInStock
                                     };

            // now for every "row" in Order_Details table, we get as many rows are in the Products table 
            // n * m rows (not very useful)  we are listing every allowable Product for each Order_Details
            // need to limit collection to rows where ProductID matches, that says not that Order_Detail item "could"
            // have that product, but rather, each product that WAS on that unique Order_Detail

            // remove the // in the where clause to make it an inner join

            // going from Order_Detail (frist from) to Product (2nd from) is a many to one
            // The same OrderID can show up, but its not a one to many, as each time an OrderID shows up 
            // it is coming from the unique orderID of each Order_Detail

            //==================================================================

            // since that was a many to one, it could be done without a join, using the nav prop

            //var ProductCollection4 = from oneOrderDetail in myEntities.Order_Details
            //                         where oneOrderDetail.Quantity > 80    //&& oneOrderDetail.ProductID == oneProduct.ProductID
            //                         orderby oneOrderDetail.OrderID ascending
            //                         select new
            //                         {
            //                             oneOrderDetail.OrderID,
            //                             oneOrderDetail.Quantity,
            //                             oneOrderDetail.UnitPrice,
            //                             oneOrderDetail.Product.ProductName,
            //                             oneOrderDetail.Product.UnitsInStock
            //                         };


            return Json(ProductCollection4);
        }
    }
}
