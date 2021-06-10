using System;
using Newtonsoft.Json;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Responses
{
    public class PostSendEmailResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}