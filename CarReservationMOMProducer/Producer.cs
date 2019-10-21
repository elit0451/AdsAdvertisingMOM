using System;
using RabbitMQ.Client;
using System.Text;
using System.Linq;

namespace CarReservationMOMProducer
{
    class Producer
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "10.211.55.2" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "ads",
                                        type: "direct");

                while (true)
                {
                    Console.WriteLine("Press Ctrl+C to exit.");
                    Console.WriteLine("\nWhich type of ad do you want to promote?");
                    string option = Console.ReadLine();
                    Console.WriteLine("\nWhat is the ad message?");
                    string message = Console.ReadLine();

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "ads",
                                         routingKey: option,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", option, message);

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
