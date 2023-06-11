



using cb2wled;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureAppConfiguration(c => { })
     .ConfigureLogging(c => { })
     .ConfigureServices((context, services) =>
     {
         services.AddOptions<CbPollerConfig>().PostConfigure(config =>
         {
             config.PollingUri = new Uri(args[0]);
         });
         services.AddHostedService<CbEventPoller>()
                .AddHttpClient<CbEventPoller>();

     })
     .Build();


host.Run();
