using System.Threading.Tasks;
using API.CQRS.Sample.Contracts.CommandHandlers;
using API.CQRS.Sample.Contracts.QueryHandlers;
using API.CQRS.Sample.RequestModels.CommandRequestModels;
using API.CQRS.Sample.RequestModels.QueryRequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.CQRS.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        //private readonly ISaveProductCommandHandler _saveProductCommandHandler;
        //private readonly IAllProductsQueryHandler _allProductsQueryHandler;
        //private readonly IPriceRangeProductsQueryHandler _priceRangeProductsQueryHandler;
        private readonly IMediator _mediator;
        public ProductController(
            //ISaveProductCommandHandler saveProductCommandHandler,
            //IAllProductsQueryHandler allProductsQueryHandler,
            //IPriceRangeProductsQueryHandler priceRangeProductsQueryHandler,
            IMediator mediator)
        {
            //_saveProductCommandHandler = saveProductCommandHandler;
           // _allProductsQueryHandler = allProductsQueryHandler;
            //_priceRangeProductsQueryHandler = priceRangeProductsQueryHandler;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequestModel requestModel)
        {
            //var result = await _saveProductCommandHandler.SaveAsync(requestModel);
            var result = await _mediator.Send(requestModel);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllProducts()
        {
            //var result = await _allProductsQueryHandler.GetListAsync();
            var result = await _mediator.Send(new AllProductsRequestModel());
            return Ok(result);
        }

        [HttpGet]
        [Route("price-range")]
        public async Task<IActionResult> PriceRangeProducts([FromQuery]PriceRangeProductsRequestModel requestModel)
        {
            //var result = await _priceRangeProductsQueryHandler.PriceRangeProductsAsync(minPrice, maxPrice);
            var result = await _mediator.Send(requestModel);
            return Ok(result);
        }
    }
}