using System;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Application.Services;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Responses;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Application.Services
{
    public class WhenSendingStopSharingDemandEmail
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called_And_Email_Sent(
            Guid id,
            [Frozen] Mock<IApiClient> apiClient,
            EmployerDemandService service)
        {
            //Act
            await service.SendAutomaticStopSharingEmail(id);
            
            //Assert
            apiClient.Verify(
                x => x.Post<PostSendEmailResponse>(It.Is<PostSendAutomaticStopSharedDemandRequest>(c => c.PostUrl.Contains(id.ToString()))),
                Times.Once);
        }
    }
}