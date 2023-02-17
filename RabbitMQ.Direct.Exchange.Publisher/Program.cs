using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://befjdvjy:X6brcqMd4AMZmJKYHu6RshOAyBD08E0P@moose.rmq.cloudamqp.com/befjdvjy");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);

while (true)
{
    Console.Write("Mesaj : ");
    string message = Console.ReadLine();
    byte[] byteMessage = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "direct-exchange-example", 
        routingKey: "direct-queue-example",
        body: byteMessage);
}

Console.Read();