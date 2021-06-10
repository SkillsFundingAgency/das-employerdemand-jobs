using System;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class PostSendAutomaticStopSharedDemandRequest : IPostApiRequest
    {
        private readonly Guid _id;
        private readonly Guid _courseDemandId;

        public PostSendAutomaticStopSharedDemandRequest(Guid id, Guid courseDemandId)
        {
            _id = id;
            _courseDemandId = courseDemandId;
        }

        public string PostUrl => $"demand/{_courseDemandId}/send-automatic-stop-sharing-email/{_id}";
    }
}