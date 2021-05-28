using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Responses
{
    public class GetUnmetDemandResponse
    {
        [JsonProperty("employerDemandIds")]
        public IEnumerable<Guid> EmployerDemandIds { get; set; }
    }
}