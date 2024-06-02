using Azure.Messaging.ServiceBus;

namespace TechTraining3_02June.ServiceBusPublisher;

public class ServiceBusQueueSender
{
    private readonly string connectionString;
    private readonly string queueName;
    private ServiceBusClient client;
    private ServiceBusSender sender;

    public ServiceBusQueueSender(string connectionString, string queueName)
    {
        this.connectionString = connectionString;
        this.queueName = queueName;
        client = new ServiceBusClient(connectionString);
        sender = client.CreateSender(queueName);
    }

    public async Task SendAsync(string messageContent)
    {
        ServiceBusMessage message = new ServiceBusMessage(messageContent);
        await sender.SendMessageAsync(message);
    }

    public async ValueTask DisposeAsync()
    {
        if (sender != null)
        {
            await sender.DisposeAsync();
        }

        if (client != null)
        {
            await client.DisposeAsync();
        }
    }
}