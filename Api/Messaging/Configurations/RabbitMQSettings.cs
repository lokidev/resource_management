using Newtonsoft.Json;

// TODO: This should probably be common to the two notifications-be-XXXXXXX projects
namespace QuickSampleApi.Messaging.Configurations
{
  [JsonObject("rabbit_mq_settings")]
  public class RabbitMQSettings
  {
    [JsonProperty("host")]
    public string Host { get; set; }

    [JsonProperty("homeExchange")]
    public string HomeExchange { get; set; }

    [JsonProperty("username")]
    public string UserName { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("messageCheckIntervalInSeconds")]
    public double MessageCheckIntervalInSeconds { get; set; }

    [JsonProperty("numberOfConnectionRetries")]
    public int NumberOfConnectionRetries { get; set; }

    [JsonProperty("connectionRetryInterval")]
    public int ConnectionRetryInterval { get; set; }

    [JsonProperty("autoRecoveryInterval")]
    public int AutoRecoveryInterval { get; set; }

    [JsonProperty("exchanges")]
    public RabbitMQExchanges Exchanges { get; set; }

    [JsonProperty("listeningTopics")]
    public string[] ListeningTopics { get; set; }
  }
}