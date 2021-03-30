namespace API.CQRS.Sample.ResponseModels.QueryResponseModels
{
    public class PriceRangeProductsResponseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}