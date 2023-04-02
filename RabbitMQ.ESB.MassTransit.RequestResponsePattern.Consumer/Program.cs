using MassTransit;
using RabbitMQ.ESB.MassTransit.RequestResponsePattern.Consumer.Consumers;

Console.WriteLine("Consumer");

string rabbitMQUri = "amqps://befjdvjy:bs5zD-4j8OfHQrZFUOnEAKomCudYmkL1@moose.rmq.cloudamqp.com/befjdvjy";

string requestQueue = "request-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);

    factory.ReceiveEndpoint(requestQueue, endpoint =>
    {
        endpoint.Consumer<ReqeustMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();