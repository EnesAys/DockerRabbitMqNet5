using System.Text;
using RabbitMQ.Client;

namespace Net5RabbitMqProducerApi.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendNameToQueue(string name)
        {           
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "enes", Password = "enes123" };//Konfigurasyondan alınabilir            
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {                
                channel.QueueDeclare(queue: "NameQueue",
                    durable: false, //Data saklama yöntemi (memory-fiziksel)
                    exclusive: false, //Başka bağlantıların kuyrupa ulaşmasını istersek true kullanabiliriz.
                    autoDelete: false, 
                    arguments: null);//Exchange parametre tanımları.          
                          
                var body = Encoding.UTF8.GetBytes(name); //Model alınarak json serialize uygulanabilir.
                
                channel.BasicPublish(exchange: "",
                    routingKey: "NameQueue", 
                    body: body);
            }
        }
    }
}