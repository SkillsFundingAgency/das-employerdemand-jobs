using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Responses;

namespace SFA.DAS.EmployerDemand.Jobs.Application.Services
{
    public class EmployerDemandService : IEmployerDemandService
    {
        private readonly IApiClient _apiClient;

        public EmployerDemandService (IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IEnumerable<Guid>> GetUnmetDemands()
        {
            var sevenDayDemands = _apiClient.Get<GetUnmetDemandResponse>(new GetUnmetDemandRequest(7));
            var fortyTwoDayDemands = _apiClient.Get<GetUnmetDemandResponse>(new GetUnmetDemandRequest(42));

            await Task.WhenAll(sevenDayDemands, fortyTwoDayDemands);

            var demandIds = new List<Guid>();
            demandIds.AddRange(sevenDayDemands.Result.EmployerDemandIds);
            demandIds.AddRange(fortyTwoDayDemands.Result.EmployerDemandIds);
            
            return demandIds;
        }

        public Task SendReminderEmail(Guid shortListId)
        {
            throw new NotImplementedException();
        }
    }
}