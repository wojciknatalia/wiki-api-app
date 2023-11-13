using backend.Controllers;
using backend.Data;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendTests
{
    public class WordCountControllerTests
	{
        [Fact]
        public async Task GetCreditData_ReturnsOkObjectResult_WithWordCountData()
        {
            Mock<IWordCountService> wordCountServiceMock = new Mock<IWordCountService>();
            WordCountController controller = new WordCountController(wordCountServiceMock.Object);
            string topic = "apple";
            WordCountData wordCountData = new WordCountData() { WordCount = 18 };

            wordCountServiceMock.Setup(service => service.GetWordCount(topic))
                                .ReturnsAsync(wordCountData);

            IActionResult result = await controller.GetCreditData(topic);

            ObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            WordCountData returnedWordCount = Assert.IsType<WordCountData>(okResult.Value);
            Assert.Equal(wordCountData.WordCount, returnedWordCount.WordCount);
        }
    }
}

