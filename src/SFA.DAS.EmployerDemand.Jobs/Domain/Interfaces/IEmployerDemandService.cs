using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces
{
    public interface IEmployerDemandService
    {
        Task<IEnumerable<Guid>> GetUnmetDemands();
        Task SendReminderEmail(Guid shortListId);
    }
}