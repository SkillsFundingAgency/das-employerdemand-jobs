using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingGetDemandsOlderThan3YearsRequest
    {
        [Test]
        public void Then_Url_Set_Correctly()
        {
            //Act
            var actual = new GetDemandsOlderThan3YearsRequest();
            
            //Assert
            actual.GetUrl.Should().Be("demand/older-than-3-years");
        }
    }
}