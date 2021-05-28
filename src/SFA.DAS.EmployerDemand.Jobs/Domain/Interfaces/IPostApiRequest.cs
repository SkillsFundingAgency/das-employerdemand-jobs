using Newtonsoft.Json;

namespace SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces
{
    public interface IPostApiRequest
    {
        [JsonIgnore]
        string PostUrl { get; }
    }
}