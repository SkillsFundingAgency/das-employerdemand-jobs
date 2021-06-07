using Newtonsoft.Json;

namespace SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces
{
    public interface IGetApiRequest
    {
        [JsonIgnore]
        string GetUrl { get; }
    }
}