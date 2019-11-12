using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace FCGSampleData.Controllers
{

    public class ProductsController : ODataController
    {
        private AdventureWorksContext _db;

        public ProductsController(AdventureWorksContext context)
        {
            _db = context;
            if (context.Products.Count() == 0)
            {
                foreach (var p in adventureworksDataSource.GetProducts())
                {
                    context.Products.Add(p);
                }

                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Products);
        }

        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            return Ok(_db.Products.FirstOrDefault(c => c.Id == key));
        }

    }
}
