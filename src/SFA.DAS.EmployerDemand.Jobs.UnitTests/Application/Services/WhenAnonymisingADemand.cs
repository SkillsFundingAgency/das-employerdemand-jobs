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
    public class WhenAnonymisingADemand
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called(
            Guid id,
            [Frozen] Mock<IApiClient> mockApiClient,
            EmployerDemandService service)
        {
            //Act
            await service.AnonymiseDemand(id);
            
            //Assert
            mockApiClient.Verify(
                x => x.Post<PostAnonymiseDemandResponse>(It.Is<PostAnonymiseDemandRequest>(c => c.PostUrl.Contains(id.ToString()))),
                Times.Once);
        }
    }
}