using Newtonsoft.Json;

namespace QuickSampleApi.Messaging.Configurations
{
  [JsonObject("rabbit_mq_exchanges")]
  public class RabbitMQExchanges
  {
    [JsonProperty("sampleConsume1Exchange")]
    public string sampleConsume1Exchange { get; set; }
    [JsonProperty("sampleConsume2Exchange")]
    public string sampleConsume2Exchange { get; set; }
    }
}
