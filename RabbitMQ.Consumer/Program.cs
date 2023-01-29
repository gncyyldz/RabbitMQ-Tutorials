using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Bağlantı Oluşturma
ConnectionFactory factory = new();
factory.Uri = new("amqps://befjdvjy:TbpYTaE6qqoRmL0ftZ3D2u5CiXvnuMPe@moose.rmq.cloudamqp.com/befjdvjy");

//Bağlantı Aktifleştirme ve Kanal Açma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Oluşturma
channel.QueueDeclare(queue: "example-queue", exclusive: false);//Consumer'da da kuyruk publisher'daki ile birebir aynı yapılandırmada tanımlanmalıdır!

//Queue'dan Mesaj Okuma
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue", false, consumer);
consumer.Received += (sender, e) =>
{
    //Kuyruğa gelen mesajın işlendiği yerdir!
    //e.Body : Kuyruktaki mesajın verisini bütünsel olarak getirecektir.
    //e.Body.Span veya e.Body.ToArray() : Kuyrukdaki mesajın byte verisini getirecektir.
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};

Console.Read();