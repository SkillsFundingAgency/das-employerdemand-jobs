using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Endpoints
{
    public class SendReminderEmailsTimerTrigger
    {
        private readonly IEmployerDemandService _employerDemandService;

        public SendReminderEmailsTimerTrigger (IEmployerDemandService employerDemandService)
        {
            _employerDemandService = employerDemandService;
        }
        
        [FunctionName("SendReminderEmailsTimerTrigger")]
        public async Task RunAsync(
            [TimerTrigger("0 0 9 * * *")] TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"Get employer demand reminder emails timer trigger function executed at: {DateTime.UtcNow}");

            var courseDemandIds = (await _employerDemandService.GetUnmetDemands()).ToList();

            foreach (var courseDemandId in courseDemandIds)
            {
                await _employerDemandService.SendReminderEmail(courseDemandId);
            }
        }
        
    }
}