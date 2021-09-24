using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Threading;
using QuickSampleApi.Messaging.Interfaces;
using QuickSampleApi.Messaging.Configurations;

namespace QuickSampleApi.Messaging.Services
{
  /// <summary>
  /// Singleton service used to 
  /// </summary>
  public class RabbitMqService: IRabbitMqService, IDisposable
  {
    private ConnectionFactory connectionFactory;
    private IConnection connection;
    private IModel model;
    
    private RabbitMQSettings configuration;
    private ILogger<RabbitMqService> logger;

    /// <summary>
    /// Singleton class used to send messages on mission mapping's
    /// main home exchange.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="logger"></param>
    public RabbitMqService(
      IOptions<RabbitMQSettings> configuration,
      ILogger<RabbitMqService> logger)
    {
      this.configuration = configuration.Value;
      this.logger = logger;

      BuildConnection();
    }

    private void BuildConnection()
    {
      //Main entry point to the RabbitMQ .NET AMQP client

      this.connectionFactory = new ConnectionFactory()
      {
        UserName = configuration.UserName,
        Password = configuration.Password,
        HostName = configuration.Host
      };

      bool success = false;
      int tries = 0;
      while (!success && tries <= configuration.NumberOfConnectionRetries)
      {
        try
        {
          this.connection = connectionFactory.CreateConnection();
          logger.LogInformation("RabbitMQ Connection for RabbitMQService successfully opened");
          success = true;
        }
        catch (BrokerUnreachableException)
        {
          logger.LogWarning($"Unable to reach RabbitMQ server. Retrying in {configuration.ConnectionRetryInterval} seconds...");
          tries++;
          Thread.Sleep(configuration.ConnectionRetryInterval * 1000);
        }
        catch (AuthenticationFailureException)
        {
          logger.LogError("Username and/or Password in RabbitMQSettings is incorrect. Check configuration values and restart this pod");
          return;
        }
      }

      if(!success)
      {
        logger.LogError("Connection to RabbitMQ failed in RabbitMQService. Messages will not be sent. Check settings and restart this pod.");
        return;
      }

      model = connection.CreateModel();

      // Create Exchange
      model.ExchangeDeclare(configuration.HomeExchange, ExchangeType.Topic, true, false, null);
    }

    /// <summary>
    /// Sends a message on Mission Mapping's home exchange
    /// </summary>
    /// <param name="payload">
    /// The data to send
    /// </param>
    /// <param name="routingKey">
    /// The topic key that listening queues use to determine interest
    /// in a message.
    /// </param>
    /// <param name="persistent">
    /// Whether this message should persist
    /// </param>
    public void sendMessage(object payload, string routingKey, bool persistent)
    {
      var properties = model.CreateBasicProperties();
      properties.Persistent = persistent;

      string json = JsonConvert.SerializeObject(payload, Formatting.Indented);
      byte[] messagebuffer = Encoding.Default.GetBytes(json);
      
      model.BasicPublish(configuration.HomeExchange, routingKey, properties, messagebuffer);
    }

    /// <summary>
    /// Handles cleanup of unmanaged resouces
    /// </summary>
    public void Dispose()
    {
      logger.LogInformation("Closing RabbitMQ Connection for RabbitMqService...");

      if (model != null && model.IsOpen)
      {
        model.Close();
      }

      if (connection != null && connection.IsOpen)
      {
        connection.Close();
      }

      logger.LogInformation("Connection for RabbitMqService Closed");
    }
  }
}