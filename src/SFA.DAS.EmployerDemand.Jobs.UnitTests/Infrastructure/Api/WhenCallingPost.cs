using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using SFA.DAS.EmployerDemand.Jobs.Domain.Configuration;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api;

namespace SFA.DAS.EmployerDemand.Jobs.UnitTests.Infrastructure.Api
{
    public class WhenCallingPost
    {
        [Test, AutoData]
        public async Task Then_The_Endpoint_Is_Called(
            Guid responseId,
            int id,
            EmployerDemandJobsApiConfiguration config)
        {
            //Arrange
            config.BaseUrl = $"https://test.local/{config.BaseUrl}/";
            var configMock = new Mock<IOptions<EmployerDemandJobsApiConfiguration>>();
            configMock.Setup(x => x.Value).Returns(config);
            var response = new HttpResponseMessage
            {
                Content = new StringContent($"'{responseId}'"),
                StatusCode = HttpStatusCode.Created
            };
            var postTestRequest = new PostTestRequest(id);
            var httpMessageHandler = MessageHandler.SetupMessageHandlerMock(response, config.BaseUrl + postTestRequest.PostUrl, config.Key, HttpMethod.Post);
            var client = new HttpClient(httpMessageHandler.Object);
            var apiClient = new ApiClient(client, configMock.Object);
            
            
            //Act
            var actual = await apiClient.Post<Guid>(postTestRequest);

            //Assert
            httpMessageHandler.Protected()
                .Verify<Task<HttpResponseMessage>>(
                    "SendAsync", Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(c =>
                        c.Method.Equals(HttpMethod.Post)
                        && c.RequestUri.AbsoluteUri.Contains(postTestRequest.PostUrl)),
                    ItExpr.IsAny<CancellationToken>()
                );
            actual.Should().Be(responseId);
        }
        
        [Test, AutoData]
        public void Then_If_It_Is_Not_Successful_An_Exception_Is_Thrown(
            int id,
            EmployerDemandJobsApiConfiguration config)
        {
            //Arrange
            config.BaseUrl = $"https://test.local/{config.BaseUrl}/";
            var configMock = new Mock<IOptions<EmployerDemandJobsApiConfiguration>>();
            configMock.Setup(x => x.Value).Returns(config);
            var response = new HttpResponseMessage
            {
                Content = null,
                StatusCode = HttpStatusCode.BadRequest
            };
            var postTestRequest = new PostTestRequest(id);
            var expectedUrl = config.BaseUrl + postTestRequest.PostUrl;
            var httpMessageHandler = MessageHandler.SetupMessageHandlerMock(response, expectedUrl, config.Key, HttpMethod.Post);
            var client = new HttpClient(httpMessageHandler.Object);
            var apiClient = new ApiClient(client, configMock.Object);
            
            //Act Assert
            Assert.ThrowsAsync<HttpRequestException>(() => apiClient.Post<Guid>(postTestRequest));
            
        }
        
        private class PostTestRequest : IPostApiRequest
        {
            private readonly int _id;

            public PostTestRequest (int id)
            {
                _id = id;
            }
            public string PostUrl => $"test-url/post/{_id}";
        }

    }
}