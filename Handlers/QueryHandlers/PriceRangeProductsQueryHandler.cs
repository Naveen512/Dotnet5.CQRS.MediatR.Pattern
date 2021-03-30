using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.CQRS.Sample.Contracts.QueryHandlers;
using API.CQRS.Sample.Data;
using API.CQRS.Sample.RequestModels.QueryRequestModels;
using API.CQRS.Sample.ResponseModels.QueryResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.CQRS.Sample.Handlers.QueryHandlers
{

    public class PriceRangeProductsQueryHandler : IRequestHandler<PriceRangeProductsRequestModel, List<PriceRangeProductsResponseModel>>
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public PriceRangeProductsQueryHandler(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }
        public async Task<List<PriceRangeProductsResponseModel>> Handle(PriceRangeProductsRequestModel request, CancellationToken cancellationToken)
        {
            
            return await _myWorldDbContext.Products
            .Where(_ => _.Price >= request.MinPrice && _.Price <= request.MaxPrice)
            .Select(_ => new PriceRangeProductsResponseModel
            {
                Name = _.Name,
                ProductId = _.ProductId,
                Price = _.Price
            }).ToListAsync();
        }
    }
    // public class PriceRangeProductsQueryHandler : IPriceRangeProductsQueryHandler
    // {
    //     private readonly MyWorldDbContext _myWorldDbContext;
    //     public PriceRangeProductsQueryHandler(MyWorldDbContext myWorldDbContext)
    //     {
    //         _myWorldDbContext = myWorldDbContext;
    //     }
    //     public async Task<List<PriceRangeProductsResponseModel>> PriceRangeProductsAsync(int minPrice, int maxPrice)
    //     {
    //         return await _myWorldDbContext.Products
    //         .Where(_ => _.Price >= minPrice && _.Price <= maxPrice)
    //         .Select(_ => new PriceRangeProductsResponseModel
    //         {
    //             Name = _.Name,
    //             ProductId = _.ProductId,
    //             Price = _.Price
    //         }).ToListAsync();
    //     }
    // }
}