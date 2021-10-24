namespace Net5RabbitMqProducerApi.Services
{
    public interface IRabbitMqService
    {
        void SendNameToQueue(string name);
    }
}