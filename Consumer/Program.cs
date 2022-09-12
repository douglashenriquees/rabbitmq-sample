using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare("saudacao_1", false, false, false, null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [X] Recebida: {message}");
        };

        channel.BasicConsume(queue: "saudacao_1", autoAck: true, consumer: consumer);

        Console.ReadLine();
    }
}