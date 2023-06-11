using cb2wled.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace cb2wled
{
    public class CbEventPoller : BackgroundService
    {

        private readonly ILogger<CbEventPoller> logger;
        private readonly Uri initialUri;
        private readonly HttpClient httpClient;

        public CbEventPoller(ILogger<CbEventPoller> logger, IOptions<CbPollerConfig> config, HttpClient httpClient)
        {
            this.logger = logger;

            this.httpClient = httpClient;

            int timeout = 20;

            UriBuilder builder = new(config.Value.PollingUri)
            {
                Query = string.Format("timeout={0}", timeout)
            };
            initialUri = builder.Uri;

            httpClient.Timeout = TimeSpan.FromSeconds(timeout * 1.5);
        }




        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            Uri nextUri = initialUri;
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Polling {uri}", nextUri);
                // var response = await httpClient.GetFromJsonAsync(
                //    nextUri, PollSerializerContext.Default.PollResponse, stoppingToken);
                var message = await httpClient.GetStringAsync(
                                       nextUri, stoppingToken);
                logger.LogInformation("Response {message}",message);
                var response = JsonSerializer.Deserialize<PollResponse>(message, PollSerializerContext.Default.PollResponse);

                logger.LogInformation("Got {count} events", response?.Events.Count ?? 0);

                nextUri = response?.NextUrl ?? initialUri;
            }
        }
    }
}