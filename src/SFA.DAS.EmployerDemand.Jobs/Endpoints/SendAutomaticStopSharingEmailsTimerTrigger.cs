using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Endpoints
{
    public class SendAutomaticStopSharingEmailsTimerTrigger
    {
        private readonly IEmployerDemandService _employerDemandService;

        public SendAutomaticStopSharingEmailsTimerTrigger (IEmployerDemandService employerDemandService)
        {
            _employerDemandService = employerDemandService;
        }
        
        [FunctionName("SendAutomaticStopSharingEmailsTimerTrigger")]
        public async Task RunAsync(
            [TimerTrigger("0 0 9 * * *")] TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"Get employer demands to automatically stop sharing details timer trigger function executed at: {DateTime.UtcNow}");

            var courseDemandIds = (await _employerDemandService.GetDemandsToAutomaticallyStop()).ToList();

            foreach (var courseDemandId in courseDemandIds)
            {
                await _employerDemandService.SendAutomaticStopSharingEmail(courseDemandId);
            }
        }
        
    }
}