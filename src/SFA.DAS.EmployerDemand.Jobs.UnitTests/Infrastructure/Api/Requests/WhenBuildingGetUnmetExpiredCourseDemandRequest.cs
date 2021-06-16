using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingGetUnmetExpiredCourseDemandRequest
    {
        [Test, AutoData]
        public void Then_The_Url_Is_Correctly_Built()
        {
            //Act
            var actual = new GetUnmetExpiredCourseDemandRequest();
            
            //Assert
            actual.GetUrl.Should().Be("demand/unmet/expired-course");
        }
    }
}