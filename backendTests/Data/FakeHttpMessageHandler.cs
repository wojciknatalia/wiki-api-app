using System.Net;

namespace backendTests.Data
{
    /// <summary>
    /// Custom implementation of HttpMessageHandler for testing purposes
    /// </summary>
	public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public HttpResponseMessage ExpectedResponse { get; set; } = new HttpResponseMessage(HttpStatusCode.OK);

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Simulate the behavior of a real HTTP client
            return Task.FromResult(ExpectedResponse);
        }
    }
}

