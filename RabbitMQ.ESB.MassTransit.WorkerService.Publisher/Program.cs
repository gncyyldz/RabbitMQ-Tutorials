
using MassTransit;
using RabbitMQ.ESB.MassTransit.WorkerService.Publisher.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host("amqps://befjdvjy:bs5zD-4j8OfHQrZFUOnEAKomCudYmkL1@moose.rmq.cloudamqp.com/befjdvjy");
            });
        });

        services.AddHostedService<PublishMessageService>(provider =>
        {
            using IServiceScope scope = provider.CreateScope();
            IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>();
            return new(publishEndpoint);
        });
    })
    .Build();

await host.RunAsync();
