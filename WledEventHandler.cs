using cb2wled;
using cb2wled.Models;

public class WledEventHandler : IEventHandler
{
    private readonly HttpClient client;

    public WledEventHandler(IHttpClientFactory clientFactory)
    {

        this.client = clientFactory.CreateClient("wled");
    }

    public async Task Handle(Event evt, CancellationToken stoppingToken)
    {
        try
        {
            
            if (evt is TipEvent tipEvent)
            {
                if (tipEvent?.Object?.Tip.Tokens >= 2)
                {
                    // for now hardcode the message
                    // to go to preset 110 for 2 seconds
                    // then back to the preset 100;
                    var messageHarcoded = """
                        {
                          "playlist": {
                            "ps": [110, 100],
                              "dur": [100, 20],
                              "transition": 0,
                              "repeat": 1,
                              "end": 100
                            }
                        }
                        """;
                    await client.PostAsync("json", new StringContent(messageHarcoded), stoppingToken);

                }
            }
            

            if (evt is ChatMessageEvent messageEvent)
            {
                if (messageEvent?.Object?.message?.Message?.Contains("blink") ?? false)
                {

                    // for now hardcode the message
                    // to go to preset 110 for 2 seconds
                    // then back to the preset 100;
                    var messageHarcoded = """
                        {
                          "playlist": {
                            "ps": [110, 100],
                              "dur": [20, 20],
                              "transition": 0,
                              "repeat": 1,
                              "end": 100
                            }
                        }
                        """;
                    await client.PostAsync("json", new StringContent(messageHarcoded), stoppingToken);


                }
            }
            


        }
        catch (Exception)
        {
            // TODO : log
        }
     
    }
}