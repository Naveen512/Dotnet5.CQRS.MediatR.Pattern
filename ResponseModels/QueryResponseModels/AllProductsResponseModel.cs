namespace API.CQRS.Sample.ResponseModels.QueryResponseModels
{
    public class AllProductsResponseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}