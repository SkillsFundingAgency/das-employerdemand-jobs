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
    public class WhenSendingCourseStoppedDemandEmail
    {
        [Test, MoqAutoData]
        public async Task Then_The_Request_Is_Processed(
            Guid id,
            Guid demandId,
            PostSendEmailResponse response,
            [Frozen] Mock<IApiClient> apiClient,
            EmployerDemandService service)
        {
            //Act
            await service.SendCourseStoppedEmail(demandId);

            //Assert
            apiClient.Verify(
                x => x.Post<PostSendEmailResponse>(It.Is<PostSendCourseStoppedRequest>(c =>
                    c.PostUrl.Contains(demandId.ToString()))), Times.Once);
        }
    }
}