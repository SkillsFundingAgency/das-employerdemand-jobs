using System;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class PostSendCourseStoppedRequest : IPostApiRequest
    {
        private readonly Guid _id;
        private readonly Guid _courseDemandId;

        public PostSendCourseStoppedRequest(Guid id, Guid courseDemandId)
        {
            _id = id;
            _courseDemandId = courseDemandId;
        }

        public string PostUrl => $"demand/{_courseDemandId}/send-course-stopped-email/{_id}";
    }
}