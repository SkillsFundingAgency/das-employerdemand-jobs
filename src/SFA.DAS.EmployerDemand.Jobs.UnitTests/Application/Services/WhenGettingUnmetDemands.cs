using System;
using System.Collections.Generic;
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
    public class WhenGettingUnmetDemands
    {
        [Test, MoqAutoData]
        public async Task Then_The_Api_Is_Called_To_Get_Demands_That_Are_Seven_And_Forty_Two_Days_Old(
            GetUnmetDemandResponse response1,
            GetUnmetDemandResponse response2,
            [Frozen] Mock<IApiClient> apiClient,
            EmployerDemandService service)
        {
            //Arrange
            apiClient.Setup(x =>
                    x.Get<GetUnmetDemandResponse>(
                        It.Is<GetUnmetDemandRequest>(c => c.GetUrl.EndsWith("unmet?demandAgeInDays=7"))))
                .ReturnsAsync(response1);
            apiClient.Setup(x =>
                    x.Get<GetUnmetDemandResponse>(
                        It.Is<GetUnmetDemandRequest>(c => c.GetUrl.EndsWith("unmet?demandAgeInDays=42"))))
                .ReturnsAsync(response2);
            
            //Act
            var actual = await service.GetUnmetDemands();
            
            //Assert
            var expectedList = new List<Guid>();
            expectedList.AddRange(response1.EmployerDemandIds);
            expectedList.AddRange(response2.EmployerDemandIds);
            actual.Should().BeEquivalentTo(expectedList);
        }
    }
}