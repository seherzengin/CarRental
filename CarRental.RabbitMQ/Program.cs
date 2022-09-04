using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://xdcxgria:bZA8XiVTSevqUDBoyx4oc26T6URxflA2@shark.rmq.cloudamqp.com/xdcxgria");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("user", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"User message received: {message}");
};
//read the message
channel.BasicConsume(queue: "user", autoAck: true, consumer: consumer);
Console.ReadKey();