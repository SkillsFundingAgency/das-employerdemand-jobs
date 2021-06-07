using System.Threading.Tasks;

namespace SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces
{
    public interface IApiClient
    {
        Task<TResponse> Get<TResponse>(IGetApiRequest request);
        Task<TResponse> Post<TResponse>(IPostApiRequest request);
    }
}