using System;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Requests;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Infrastructure.Api.Requests
{
    public class WhenBuildingPostSendCourseStoppedRequest
    {
        [Test, AutoData]
        public void Then_The_Url_Is_Correctly_Constructed(Guid id, Guid courseDemandId)
        {
            //Act
            var actual = new PostSendCourseStoppedRequest(id, courseDemandId);
            
            //Assert
            actual.PostUrl.Should().Be($"demand/{courseDemandId}/send-course-stopped-email/{id}");
        }
    }
}