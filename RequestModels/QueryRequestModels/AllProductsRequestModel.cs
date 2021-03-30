using System.Collections.Generic;
using API.CQRS.Sample.ResponseModels.QueryResponseModels;
using MediatR;

namespace API.CQRS.Sample.RequestModels.QueryRequestModels
{
    public class AllProductsRequestModel:IRequest<List<AllProductsResponseModel>>
    {

    }
}