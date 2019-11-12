using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AdventureWorksContext : DbContext
{
    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
      : base(options)
    {
    }

    public DbSet<AdventureWorks.Product> Products { get; set; }
    public DbSet<AdventureWorks.Order> Orders { get; set; }

    public DbSet<AdventureWorks.OrderDetail> OrderDetails { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<AdventureWorks.Product>().OwnsOne(c => c.Code);
    //}
}