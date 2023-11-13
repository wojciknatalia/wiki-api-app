using backend.Data;
using backend.Services;

namespace backendTests
{
    public class WordCountServiceTests
	{
        [Fact]
        public async Task GetWordCount_ReturnsWordCountData_WhenApiDataIsNotNull()
        {
            Mock<IWikiDataService> wikiDataServiceMock = new Mock<IWikiDataService>();
            WordCountService wordCountService = new WordCountService(wikiDataServiceMock.Object);
            string topic = "apple";
            WikiApiResponse apiData = new WikiApiResponse { WikiData = new WikiData { Text = new WikiTextData { Content = "Apple" } } };

            wikiDataServiceMock.Setup(service => service.GetData(topic))
                               .ReturnsAsync(apiData);

            WordCountData result = await wordCountService.GetWordCount(topic);

            Assert.NotNull(result);
            Assert.Equal(1, result.WordCount);
        }

        [Fact]
        public async Task GetWordCount_ReturnsWordCountDataCaseSensitive_WhenApiDataIsNotNull()
        {
            Mock<IWikiDataService> wikiDataServiceMock = new Mock<IWikiDataService>();
            WordCountService wordCountService = new WordCountService(wikiDataServiceMock.Object);
            string topic = "apple";
            WikiApiResponse apiData = new WikiApiResponse { WikiData = new WikiData { Text = new WikiTextData { Content = "Apple apples" } } };

            wikiDataServiceMock.Setup(service => service.GetData(topic))
                               .ReturnsAsync(apiData);

            WordCountData result = await wordCountService.GetWordCount(topic);

            Assert.NotNull(result);
            Assert.Equal(1, result.WordCount);
        }

        [Fact]
        public async Task GetWordCount_ReturnsWordCountData_WhenApiDataIsNull()
        {
            Mock<IWikiDataService> wikiDataServiceMock = new Mock<IWikiDataService>();
            WordCountService wordCountService = new WordCountService(wikiDataServiceMock.Object);
            string topic = "apple";

            wikiDataServiceMock.Setup(service => service.GetData(topic))
                               .ReturnsAsync(null as WikiApiResponse);

            WordCountData result = await wordCountService.GetWordCount(topic);

            Assert.NotNull(result);
            Assert.Equal(0, result.WordCount);
        }
    }
}

