using MassTransit;
using RabbitMQ.ESB.MassTransit.Shared.Messages;

namespace RabbitMQ.ESB.MassTransit.Consumer.Consumers
{
    public class ExampleMessageConsumer : IConsumer<IMessage>
    {
        public Task Consume(ConsumeContext<IMessage> context)
        {
            Console.WriteLine($"Gelen mesaj : {context.Message.Text}");
            return Task.CompletedTask;
        }
    }
}
