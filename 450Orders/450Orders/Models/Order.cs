using System;

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