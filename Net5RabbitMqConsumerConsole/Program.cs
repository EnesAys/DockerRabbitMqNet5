using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Net5RabbitMqConsumerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "enes", Password = "enes123" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" Welcome {message}");
                };
                channel.BasicConsume(queue: "NameQueue", //Kuyruk adı
                    autoAck: true, //Kuruk adı doğrulanması
                    consumer: consumer);                
                Console.ReadLine();
            }            
        }
    }
}
