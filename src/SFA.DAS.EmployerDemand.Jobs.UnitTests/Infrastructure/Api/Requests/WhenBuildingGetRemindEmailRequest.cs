using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingGetRemindEmailRequest
    {
        [Test, AutoData]
        public void Then_The_Url_Is_Correctly_Constructed(uint demandAgeInDays)
        {
            //Act
            var actual = new GetUnmetDemandRequest(demandAgeInDays);

            //Assert
            actual.GetUrl.Should().Be($"demand/unmet?demandAgeInDays={demandAgeInDays}");
        }
    }
}