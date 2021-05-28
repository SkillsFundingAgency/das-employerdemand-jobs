using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class GetUnmetDemandRequest : IGetApiRequest
    {
        private readonly uint _demandAgeInDays;

        public GetUnmetDemandRequest(uint demandAgeInDays)
        {
            _demandAgeInDays = demandAgeInDays;
        }

        public string GetUrl => $"demand/unmet?demandAgeInDays={_demandAgeInDays}";
    }
}