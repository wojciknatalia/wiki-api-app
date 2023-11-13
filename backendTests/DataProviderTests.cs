using System.Net;
using backend.Providers;
using backendTests.Data;

namespace backendTests
{
    public class DataProviderTests
	{
        [Fact]
        public async Task GetData_ReturnsResponse_WhenHttpClientFactoryReturnsClient()
        {
            Mock<IHttpClientFactory> httpClientFactoryMock = new Mock<IHttpClientFactory>();
            DataProvider dataProvider = new DataProvider(httpClientFactoryMock.Object);
            HttpResponseMessage expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(new FakeHttpMessageHandler { ExpectedResponse = expectedResponse })
                {
                    BaseAddress = new Uri("https://en.wikipedia.org/w/")
                });

            HttpResponseMessage response = await dataProvider.GetData("api.php?action=parse&section=0&prop=text&format=json&page=apple");

            Assert.Equal(expectedResponse, response);
        }
    }
}

