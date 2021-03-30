using MediatR;

namespace API.CQRS.Sample.RequestModels.CommandRequestModels
{
    public class SaveProductRequestModel:IRequest<int>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price{get;set;}
    }
}