namespace API.CQRS.Sample.Data.Entites
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price{get;set;}
    }
}