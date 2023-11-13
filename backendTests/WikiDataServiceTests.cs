using System.Net;
using backend.Data;
using backend.Providers;
using backend.Services;

namespace backendTests
{
    public class WikiDataServiceTests
	{
        [Fact]
        public async Task GetData_ReturnsWikiApiResponse_WhenApiCallIsSuccessful()
        {
            Mock<IDataProvider> dataProviderMock = new Mock<IDataProvider>();
            WikiDataService wikiDataService = new WikiDataService(dataProviderMock.Object);
            string topic = "apple";
            WikiApiResponse expectedApiResponse = new WikiApiResponse();

            dataProviderMock.Setup(provider => provider.GetData(It.IsAny<string>()))
                            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent("{}")
                            });

            WikiApiResponse result = await wikiDataService.GetData(topic);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetData_ReturnsNull_WhenApiCallFails()
        {
            Mock<IDataProvider> dataProviderMock = new Mock<IDataProvider>();
            WikiDataService wikiDataService = new WikiDataService(dataProviderMock.Object);
            string topic = "fff111112";

            dataProviderMock.Setup(provider => provider.GetData(topic))
                            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            WikiApiResponse result = await wikiDataService.GetData(topic);

            Assert.Null(result);
        }
    }
}

