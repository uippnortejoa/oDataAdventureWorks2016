using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace FCGSampleData.Controllers
{

    public class PressesController : ODataController
    {
        private BookStoreContext _db;

        public PressesController(BookStoreContext context)
        {
            _db = context;
            if (context.Presses.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    //context.Presses.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Presses);
        }

        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            return Ok(_db.Presses.FirstOrDefault(c => c.PressId == key));
        }

    }
}
