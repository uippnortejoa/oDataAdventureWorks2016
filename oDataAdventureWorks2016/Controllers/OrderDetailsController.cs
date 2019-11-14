using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace FCGSampleData.Controllers
{
    //Some comment
    public class OrderDetailsController : ODataController
    {
        private AdventureWorksContext _db;

        public OrderDetailsController(AdventureWorksContext context)
        {
            _db = context;
            if (context.OrderDetails.Count() == 0)
            {
                foreach (var o in adventureworksDataSource.GetOrderDetails())
                {
                    context.OrderDetails.Add(o);
                }

                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.OrderDetails);
        }

        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            return Ok(_db.OrderDetails.FirstOrDefault(c => c.Id == key));
        }

    }
}
