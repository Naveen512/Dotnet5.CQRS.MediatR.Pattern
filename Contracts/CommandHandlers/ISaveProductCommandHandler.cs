using System.Threading.Tasks;
using API.CQRS.Sample.RequestModels.CommandRequestModels;

namespace API.CQRS.Sample.Contracts.CommandHandlers
{
    // This file no longer needed on using MediatR
    public interface ISaveProductCommandHandler
    {
        Task<int> SaveAsync(SaveProductRequestModel requestModel);
    }
}