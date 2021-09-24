using Newtonsoft.Json;

namespace ResourceManagementApi.Messaging.Configurations
{
  [JsonObject("rabbit_mq_exchanges")]
  public class RabbitMQExchanges
  {
    [JsonProperty("peopleExchange")]
    public string peopleExchange { get; set; }
    [JsonProperty("worldExchange")]
    public string worldExchange { get; set; }
    }
}
