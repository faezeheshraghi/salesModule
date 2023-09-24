using System.Data;

namespace SalesModule.Models
{
    public class SalesOrder : BaseEntity
    {
        public string Customer { get; set; }

        public ICollection<SalesOrderLine> salesOrderLines { get; set; }
    }
}
