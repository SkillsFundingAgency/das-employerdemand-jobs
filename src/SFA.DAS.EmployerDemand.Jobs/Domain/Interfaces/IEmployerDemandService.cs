using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces
{
    public interface IEmployerDemandService
    {
        Task<IEnumerable<Guid>> GetUnmetDemands();
        Task SendReminderEmail(Guid courseDemandId);
        Task<IEnumerable<Guid>> GetDemandsToAutomaticallyStop();
        Task SendAutomaticStopSharingEmail(Guid courseDemandId);
        Task<IEnumerable<Guid>> GetDemandsWithExpiredCourses();
        Task SendCourseStoppedEmail(Guid courseDemandId);
        Task<IEnumerable<Guid>> GetDemandsOlderThan3Years();
        Task AnonymiseDemand(Guid courseDemandId);
    }
}