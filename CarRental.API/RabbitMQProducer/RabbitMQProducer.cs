using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace CarRental.API.RabbitMQProducer
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendUserMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://xdcxgria:bZA8XiVTSevqUDBoyx4oc26T6URxflA2@shark.rmq.cloudamqp.com/xdcxgria");



            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("user", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: "", routingKey: "user", body: body);

        }
    }
}
