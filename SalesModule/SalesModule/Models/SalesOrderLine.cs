using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SalesModule.Models
{
    public class SalesOrderLine : BaseEntity
    {
        public int Quantity { get; set; }

        
        public int ProductId { get; set; }

        public int SaleOrderId { get; set; }
        List<Product> Products { get; set; }
        List<SalesOrder> SalesOrders { get; set; }



    }
}
