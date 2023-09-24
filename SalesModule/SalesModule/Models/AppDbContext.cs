using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using SalesModule.Models;
using System.Reflection.Emit;

namespace SaleModule.Models
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<SalesOrderLine>()
            //.HasOne(ol => ol.Product)
            //.WithMany(p => p.salesOrderLines)
            //.HasForeignKey(ol => ol.ProductId);

        }


        DbSet<Product> product { get; set; }
        DbSet<SalesOrder> salesOrder { get; set; }
        DbSet<SalesOrderLine> salesOrderLine { get; set; }

    }
}
