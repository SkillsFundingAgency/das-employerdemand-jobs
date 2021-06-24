using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class GetDemandsOlderThan3YearsRequest : IGetApiRequest
    {
        public string GetUrl => "demand/older-than-3-years";
    }
}