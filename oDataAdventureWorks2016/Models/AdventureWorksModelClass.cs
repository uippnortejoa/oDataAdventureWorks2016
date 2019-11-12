using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks
{


    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }

    }


    public class Order
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid dynamicsAccountId { get; set; }
    }

    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid SalesOrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public string Name { get; set; }

    }


}
