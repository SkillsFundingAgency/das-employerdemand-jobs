using System;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests
{
    public class PostAnonymiseDemandRequest : IPostApiRequest
    {
        private readonly Guid _courseDemandId;


        public PostAnonymiseDemandRequest(Guid courseDemandId)
        {
            _courseDemandId = courseDemandId;
        }

        public string PostUrl => $"demand/{_courseDemandId}/anonymise";
    }
}