using System.Collections.Generic;
using API.CQRS.Sample.ResponseModels.QueryResponseModels;
using MediatR;

namespace API.CQRS.Sample.RequestModels.QueryRequestModels
{
    public class PriceRangeProductsRequestModel:IRequest<List<PriceRangeProductsResponseModel>>
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}