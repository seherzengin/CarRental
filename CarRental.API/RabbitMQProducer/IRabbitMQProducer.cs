namespace CarRental.API.RabbitMQProducer
{
    public interface IRabbitMQProducer
    {
        public void SendUserMessage<T>(T message);
    }
}
