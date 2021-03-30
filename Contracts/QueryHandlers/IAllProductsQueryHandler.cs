using System.Collections.Generic;
using System.Threading.Tasks;
using API.CQRS.Sample.ResponseModels.QueryResponseModels;

namespace API.CQRS.Sample.Contracts.QueryHandlers
{
     // This file no longer needed on using MediatR
    public interface IAllProductsQueryHandler
    {
        Task<List<AllProductsResponseModel>> GetListAsync();
    }
}