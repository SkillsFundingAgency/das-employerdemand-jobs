using System;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Application.Services;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Application.Services
{
    public class WhenSendingEmailReminder
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called_To_Send_Email_Reminder(
            Guid id,
            [Frozen] Mock<IApiClient> apiClient,
            EmployerDemandService service)
        {
            //Act
            await service.SendReminderEmail(id);
            
            //Assert
            apiClient.Verify(
                x => x.Post<Guid>(It.Is<PostSendReminderEmailRequest>(c => c.PostUrl.Contains(id.ToString()))),
                Times.Once);
        }
    }
}