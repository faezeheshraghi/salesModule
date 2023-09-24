namespace SalesModule.Models
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }

        public string Category { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
        public ICollection<SalesOrderLine> salesOrderLines { get; set; }
    }
}
