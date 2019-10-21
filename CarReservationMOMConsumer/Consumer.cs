using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CarReservationMOMConsumer
{
    class Consumer
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "10.211.55.2" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "ads",
                                        type: "direct");
                var queueName = channel.QueueDeclare().QueueName;

                Console.WriteLine("What kind of ads would you like to receive?");
                Console.WriteLine("\tList them separated by a comma (,)");

                string[] options = Console.ReadLine().Split(',');

                foreach (var option in options)
                {
                    channel.QueueBind(queue: queueName,
                                      exchange: "ads",
                                      routingKey: option.Trim());
                }

                Console.WriteLine(" [*] Waiting for offers.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    Console.Clear();
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine("Received an offer for '{0}'\n'{1}'",
                                      routingKey, message);

                    Console.WriteLine("\tDo you want to accept it (accept/pass)?");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(" [*] Waiting for offers.");
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine("\nPress Ctrl+C to exit.");
                while (true) { }
            }
        }
    }
}
