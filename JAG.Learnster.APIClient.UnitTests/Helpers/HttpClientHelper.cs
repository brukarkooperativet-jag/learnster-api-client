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
            handlerMock.SetupSendAsync(new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(JsonSerializer.Serialize(resultObject))
            });
        }

        public static void SetupSendWithEmptyResponse(this Mock<HttpClientHandler> handlerMock,
                                                      HttpStatusCode httpStatusCode)
        {
            handlerMock.SetupSendAsync(new HttpResponseMessage()
            {
                StatusCode = httpStatusCode
            });
        }

        private static void SetupSendAsync(this Mock<HttpClientHandler> handlerMock,
                                           HttpResponseMessage response)
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => response);
        }

        public static Mock<IHttpClientFactory> CreateHttpClientFactoryMock(Mock<HttpClientHandler> handlerMock)
        {
            var factoryMock = new Mock<IHttpClientFactory>();
            factoryMock
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(() => CreatedHttpClient(handlerMock.Object));

            return factoryMock;
        }
        
        public static Mock<ILearnsterHttpClientFactory> CreateLearnsterHttpClientFactoryMock(Mock<HttpClientHandler> handlerMock)
        {
            var factoryMock = new Mock<ILearnsterHttpClientFactory>();
            factoryMock
                .Setup(x => x.CreateAuthorizedClient())
                .ReturnsAsync(() => CreatedHttpClient(handlerMock.Object));

            return factoryMock;
        }

        private static HttpClient CreatedHttpClient(HttpClientHandler handler)
            => new(handler)
            {
                BaseAddress = new Uri("https://someTestAddress.test/")
            };
    }
}