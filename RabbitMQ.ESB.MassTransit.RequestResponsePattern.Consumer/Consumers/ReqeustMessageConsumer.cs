using MassTransit;
using RabbitMQ.ESB.MassTransit.Shared.RequestResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.ESB.MassTransit.RequestResponsePattern.Consumer.Consumers
{
    public class ReqeustMessageConsumer : IConsumer<RequestMessage>
    {
        public async Task Consume(ConsumeContext<RequestMessage> context)
        {
            //....process
            Console.WriteLine(context.Message.Text);
            await context.RespondAsync<ResponseMessage>(new() { Text = $"{context.Message.MessageNo}. response to request" });
        }
    }
}
