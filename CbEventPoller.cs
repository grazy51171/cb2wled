using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace cb2wled
{
    public class CbEventPoller : BackgroundService
    {

        private readonly ILogger<CbEventPoller> logger;
        private readonly Uri initialUri;
        private readonly HttpClient httpClient;
        private readonly IEnumerable<IEventHandler> eventHandlers;

        public CbEventPoller(ILogger<CbEventPoller> logger, IOptions<CbPollerConfig> config, HttpClient httpClient, IEnumerable<IEventHandler> eventHandlers)
        {
            this.logger = logger;

            this.httpClient = httpClient;
            this.eventHandlers = eventHandlers;

            int timeout = config.Value.Timeout;

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
                var response = await httpClient.GetFromJsonAsync(
                    nextUri, PollSerializerContext.Default.PollResponse, stoppingToken);

                if (response?.Events != null)
                {
                    foreach (var evt in response.Events)
                    {
                        await Task.WhenAll(eventHandlers.Select(h =>  h.Handle(evt, stoppingToken)));
                    }
                }

                nextUri = response?.NextUrl ?? initialUri;
            }
        }
    }
}