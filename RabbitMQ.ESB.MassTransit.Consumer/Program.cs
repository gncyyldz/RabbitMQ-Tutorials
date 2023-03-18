using MassTransit;
using RabbitMQ.ESB.MassTransit.Consumer.Consumers;

string rabbitMQUri = "amqps://befjdvjy:bs5zD-4j8OfHQrZFUOnEAKomCudYmkL1@moose.rmq.cloudamqp.com/befjdvjy";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);

    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();