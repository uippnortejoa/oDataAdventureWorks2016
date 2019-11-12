using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace FCGSampleData.Controllers
{

    public class OrdersController : ODataController
    {
        private AdventureWorksContext _db;

        public OrdersController(AdventureWorksContext context)
        {
            _db = context;
            if (context.Orders.Count() == 0)
            {
                foreach (var o in adventureworksDataSource.GetOrders())
                {
                    context.Orders.Add(o);
                }

                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Orders);
        }

        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            return Ok(_db.Orders.FirstOrDefault(c => c.Id == key));
        }

    }
}
