using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class GetUnmetExpiredCourseDemandRequest : IGetApiRequest
    {
        public string GetUrl => "demand/unmet/expired-course";
    }
}