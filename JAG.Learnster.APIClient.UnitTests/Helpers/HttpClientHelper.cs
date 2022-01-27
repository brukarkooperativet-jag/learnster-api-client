using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Interfaces;
using Moq;
using Moq.Protected;

namespace JAG.Learnster.APIClient.UnitTests.Helpers
{
    public static class HttpClientHelper
    {
        public static void SetupSend<TResult>(this Mock<HttpClientHandler> handlerMock,
                                              HttpStatusCode httpStatusCode,
                                              TResult resultObject)
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => new HttpResponseMessage()
                {
                    StatusCode = httpStatusCode,
                    Content = new StringContent(JsonSerializer.Serialize(resultObject))
                });
        }
        
        public static void SetupSendWithEmptyResponse(this Mock<HttpClientHandler> handlerMock,
                                              HttpStatusCode httpStatusCode)
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => new HttpResponseMessage()
                {
                    StatusCode = httpStatusCode
                });
        }

        public static Mock<IHttpClientFactory> CreateHttpClientFactoryMock(Mock<HttpClientHandler> handlerMock)
        {
            var factoryMock = new Mock<IHttpClientFactory>();
            factoryMock
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(() => new HttpClient(handlerMock.Object)
                {
                    BaseAddress = new Uri("https://someTestAddress.test/")
                });

            return factoryMock;
        }
        
        public static Mock<ILearnsterHttpClientFactory> CreateLearnsterHttpClientFactoryMock(Mock<HttpClientHandler> handlerMock)
        {
            var factoryMock = new Mock<ILearnsterHttpClientFactory>();
            factoryMock
                .Setup(x => x.CreateAuthorizedClient())
                .ReturnsAsync(() => new HttpClient(handlerMock.Object)
                {
                    BaseAddress = new Uri("https://someTestAddress.test/")
                });

            return factoryMock;
        }
    }
}