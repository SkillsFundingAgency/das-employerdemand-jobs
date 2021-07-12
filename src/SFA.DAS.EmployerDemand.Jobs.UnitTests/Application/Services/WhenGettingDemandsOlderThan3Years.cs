using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Application.Services;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Responses;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Application.Services
{
    public class WhenGettingDemandsOlderThan3Years
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called_To_Get_Demands_That_Are_3_Years_Old(
            GetDemandsOlderThan3YearsResponse response,
            [Frozen] Mock<IApiClient> mockApiClient,
            EmployerDemandService service)
        {
            //Arrange
            mockApiClient.Setup(x =>
                    x.Get<GetDemandsOlderThan3YearsResponse>(It.IsAny<GetDemandsOlderThan3YearsRequest>()))
                .ReturnsAsync(response);
            
            //Act
            var actual = await service.GetDemandsOlderThan3Years();
            
            //Assert
            actual.Should().BeEquivalentTo(response.EmployerDemandIds);
        }
    }
}