using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.ESB.MassTransit.Shared.RequestResponseMessages
{
    public record ResponseMessage
    {
        public string Text { get; set; }
    }
}
