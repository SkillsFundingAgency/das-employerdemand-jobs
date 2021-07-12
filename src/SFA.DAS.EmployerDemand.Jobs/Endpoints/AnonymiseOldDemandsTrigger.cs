using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Endpoints
{
    public class AnonymiseOldDemandsTrigger
    {
        private readonly IEmployerDemandService _employerDemandService;

        public AnonymiseOldDemandsTrigger(IEmployerDemandService employerDemandService)
        {
            _employerDemandService = employerDemandService;
        }

        [FunctionName("AnonymiseOldDemandsTrigger")]
        public async Task RunAsync(
            [TimerTrigger("0 0 9 * * *")] TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"Get employer demands older than 3 years to anonymise at: {DateTime.UtcNow}");

            var courseDemandIds = (await _employerDemandService.GetDemandsOlderThan3Years()).ToList();

            foreach (var courseDemandId in courseDemandIds)
            {
                await _employerDemandService.AnonymiseDemand(courseDemandId);
            }
        }
    }
}