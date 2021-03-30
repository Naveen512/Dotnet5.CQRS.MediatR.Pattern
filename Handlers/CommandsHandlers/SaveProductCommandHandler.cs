using System.Threading;
using System.Threading.Tasks;
using API.CQRS.Sample.Contracts.CommandHandlers;
using API.CQRS.Sample.Data;
using API.CQRS.Sample.Data.Entites;
using API.CQRS.Sample.RequestModels.CommandRequestModels;
using MediatR;

namespace API.CQRS.Sample.Handlers.CommandsHandlers
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductRequestModel, int>
    {
        public readonly MyWorldDbContext _myWorldDbContext;
        public SaveProductCommandHandler(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public async Task<int> Handle(SaveProductRequestModel request, CancellationToken cancellationToken)
        {
            var newProducts = new Products
            {
                Description = request.Description,
                Manufacturer = request.Manufacturer,
                Name = request.Name,
                Price = request.Price
            };

            _myWorldDbContext.Products.Add(newProducts);
            await _myWorldDbContext.SaveChangesAsync();
            return newProducts.ProductId;
        }
    }

    // public class SaveProductCommandHandler: ISaveProductCommandHandler
    // {
    //     public readonly MyWorldDbContext _myWorldDbContext;
    //     public SaveProductCommandHandler(MyWorldDbContext myWorldDbContext)
    //     {
    //         _myWorldDbContext = myWorldDbContext;
    //     }

    //     public async Task<int> SaveAsync(SaveProductRequestModel requestModel)
    //     {
    //         var newProducts = new Products
    //         {
    //             Description = requestModel.Description,
    //             Manufacturer = requestModel.Manufacturer,
    //             Name = requestModel.Name,
    //             Price = requestModel.Price
    //         };

    //         _myWorldDbContext.Products.Add(newProducts);
    //         await _myWorldDbContext.SaveChangesAsync();
    //         return newProducts.ProductId;
    //     }
    // }
}