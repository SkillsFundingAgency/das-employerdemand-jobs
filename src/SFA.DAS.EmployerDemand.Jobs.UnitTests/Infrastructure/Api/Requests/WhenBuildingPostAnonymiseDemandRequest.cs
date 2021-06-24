using System;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingPostAnonymiseDemandRequest
    {
        [Test, AutoData]
        public void Then_The_Url_Is_Correctly_Constructed(Guid demandId)
        {
            //Act
            var actual = new PostAnonymiseDemandRequest(demandId);
            
            //Assert
            actual.PostUrl.Should().Be($"demand/{demandId}/anonymise");
        }
    }
}