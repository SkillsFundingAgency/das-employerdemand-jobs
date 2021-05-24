using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SFA.DAS.EmployerDemand.Jobs.Domain.Configuration;

namespace SFA.DAS.EmployerDemand.Jobs.Endpoints
{
    public class GetEmployerDemandsHttpTrigger
    {
        private readonly IOptions<EmployerDemandJobsApiConfiguration> _config;

        public GetEmployerDemandsHttpTrigger (IOptions<EmployerDemandJobsApiConfiguration> config)
        {
            _config = config;
        }
         [FunctionName("GetEmployerDemandsHttpTrigger")]
         public async Task<string> RunAsync(
             [HttpTrigger(AuthorizationLevel.Function, "post")]
             
             HttpRequest req, ILogger log)
         {
            
            log.LogInformation($"Invoking function:{_config.Value.BaseUrl} {_config.Value.Key}.");
        
            return "Done";
         }
        
    }
}