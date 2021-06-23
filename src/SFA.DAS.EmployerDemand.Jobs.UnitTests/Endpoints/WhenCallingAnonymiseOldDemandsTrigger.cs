using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;
using SFA.DAS.EmployerDemand.Jobs.Endpoints;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Endpoints
{
    public class WhenCallingAnonymiseOldDemandsTrigger
    {
        [Test, MoqAutoData]
        public async Task Then_Calls_Service(
            TimerInfo timerInfo,
            Mock<ILogger> mockLogger,
            List<Guid> oldDemandIds,
            [Frozen] Mock<IEmployerDemandService> mockDemandService,
            AnonymiseOldDemandsTrigger trigger)
        {
            //arrange
            mockDemandService
                .Setup(service => service.GetDemandsOlderThan3Years())
                .ReturnsAsync(oldDemandIds);

            //act
            await trigger.RunAsync(timerInfo, mockLogger.Object);

            //assert
            mockDemandService.Verify(service => service.GetDemandsOlderThan3Years(), Times.Once);
            foreach (var oldDemandId in oldDemandIds)
            {
                mockDemandService.Verify(service => service.AnonymiseDemand(oldDemandId));
            }
        }
    }
}