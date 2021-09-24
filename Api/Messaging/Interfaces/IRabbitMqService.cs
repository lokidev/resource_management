namespace ResourceManagementApi.Messaging.Interfaces
{
  public interface IRabbitMqService
  {   
      void sendMessage(object payload, string routingKey, bool persist);
  }
}