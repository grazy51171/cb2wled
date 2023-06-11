



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
                .AddSingleton<IEventHandler, WledEventHandler>();


         services.AddHttpClient<CbEventPoller>();
         services.AddHttpClient("wled").ConfigureHttpClient(c=> c.BaseAddress = new Uri(args[1]));


     })
     .Build();


host.Run();
