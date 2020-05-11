using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _450Orders.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int StoreNumberID { get; set; }
        public int SalesPersonID { get; set; }
        public int CdID { get; set; }
        public int Price { get; set; }
        public DateTime Datetime { get; set; }
    }
}