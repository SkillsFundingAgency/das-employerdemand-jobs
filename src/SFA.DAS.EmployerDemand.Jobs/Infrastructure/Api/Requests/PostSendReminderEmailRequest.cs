using System;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class PostSendReminderEmailRequest : IPostApiRequest
    {
        private readonly Guid _id;
        private readonly Guid _courseDemandId;

        public PostSendReminderEmailRequest(Guid id, Guid courseDemandId)
        {
            _id = id;
            _courseDemandId = courseDemandId;
        }

        public string PostUrl => $"demand/{_courseDemandId}/send-reminder-email/{_id}";
    }
}