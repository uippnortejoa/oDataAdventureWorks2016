using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public static class adventureworksDataSource
{

    private static IList<AdventureWorks.Product> _products { get; set; }
    private static IList<AdventureWorks.Order> _orders { get; set; }

    private static IList<AdventureWorks.OrderDetail> _orderdetails { get; set; }

    public static IList<AdventureWorks.Product> GetProducts()
    {
        if (_products != null)
        {
            return _products;
        }

        _products = new List<AdventureWorks.Product>();

        var lines = System.IO.File.ReadAllLines(@"textData\products.txt");

        foreach (var line in lines)
        {
            var columns = line.Split('\t');

            //,[Name]
            //  ,[ProductNumber]
            //  ,[rowguid]
            //  ,[ModifiedDate]

            var p = new AdventureWorks.Product();
            p.Id = new Guid(columns[0]);
            p.Code = columns[1];

            p.Name = columns[2];

            DateTime modifiedOn;
            if (DateTime.TryParse(columns[3], out modifiedOn))
            {
                p.ModifiedOn = modifiedOn.ToUniversalTime();
            }
            else
            {
                p.ModifiedOn = DateTime.UtcNow;
            }

            _products.Add(p);
        }


        return _products;
    }

    public static IList<AdventureWorks.Order> GetOrders()
    {
        if (_orders != null)
        {
            return _orders;
        }

        _orders = new List<AdventureWorks.Order>();

        var lines = System.IO.File.ReadAllLines(@"textData\orders.txt");

        foreach (var line in lines)
        {
            var columns = line.Split('\t');

            //,[Name]
            //  ,[ProductNumber]
            //  ,[rowguid]
            //  ,[ModifiedDate]

            var o = new AdventureWorks.Order();

            o.Number = columns[0];
            DateTime orderDate;
            if (DateTime.TryParse(columns[1], out orderDate))
            {
                o.OrderDate = orderDate.ToUniversalTime();
            }
            else
            {
                o.OrderDate = DateTime.UtcNow;
            }

            o.CustomerId = new Guid(columns[2]);

            o.Subtotal = Convert.ToDecimal(columns[3]);
            o.Tax = Convert.ToDecimal(columns[4]);
            o.Freight = Convert.ToDecimal(columns[5]);
            o.TotalDue = Convert.ToDecimal(columns[6]);


            o.Id = new Guid(columns[7]);

            DateTime modifiedOn;
            if (DateTime.TryParse(columns[8], out modifiedOn))
            {
                o.ModifiedOn = modifiedOn.ToUniversalTime();
            }
            else
            {
                o.ModifiedOn = DateTime.UtcNow;
            }


            var sDynamicsAccountId = columns[9];
            if (sDynamicsAccountId.Length > 10)//vids
                o.dynamicsAccountId = new Guid(sDynamicsAccountId);
            else
                o.dynamicsAccountId = new Guid();

            _orders.Add(o);
        }


        return _orders;
    }

    public static IList<AdventureWorks.OrderDetail> GetOrderDetails()
    {
        if (_orderdetails != null)
        {
            return _orderdetails;
        }

        _orderdetails = new List<AdventureWorks.OrderDetail>();

        var lines = System.IO.File.ReadAllLines(@"textData\orderdetails.txt");

        foreach (var line in lines)
        {
            var columns = line.Split('\t');

            var d = new AdventureWorks.OrderDetail();
            d.Id = new Guid(columns[0]);
            d.SalesOrderId = new Guid(columns[1]);
            d.ProductId = new Guid(columns[2]);
            d.Quantity = Convert.ToInt32(columns[3]);
            d.UnitPrice = Convert.ToDecimal(columns[4]);
            d.LineTotal = Convert.ToDecimal(columns[5]);
            d.Name = columns[6];
            _orderdetails.Add(d);
        }


        return _orderdetails;
    }
}

