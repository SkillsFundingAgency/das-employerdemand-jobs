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
    public class WhenGettingDemandsToStopThroughCourseEnding
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called_And_Demands_Returned(
            GetUnmetDemandResponse apiResponse,
            [Frozen] Mock<IApiClient> client,
            EmployerDemandService service)
        {
            //Arrange
            client.Setup(x => x.Get<GetUnmetDemandResponse>(It.IsAny<GetUnmetExpiredCourseDemandRequest>()))
                .ReturnsAsync(apiResponse);
            
            //Act
            var actual = await service.GetDemandsWithExpiredCourses();
            
            //Assert
            actual.Should().BeEquivalentTo(apiResponse.EmployerDemandIds);
        }
    }
}