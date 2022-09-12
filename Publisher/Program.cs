using System.Text;
using RabbitMQ.Client;

// Definição da conexão
var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

// Conexão com um NÓ RabbitMQ
using (var connection = factory.CreateConnection())
{
    // Canal para definição de uma fila para publicar mensagens
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(
            queue: "saudacao_1", // nome da fila
            durable: false, // ativo após o servidor ser reiniciado?
            exclusive: false, // só pode ser acessada na conexão atual?
            autoDelete: false, // é removida após os consumidores utilizarem a fila?
            arguments: null);

        var message = "Bem-vindo ao RabbitMQ";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "",
            routingKey: "saudacao_1",
            basicProperties: null,
            body: body);

        Console.WriteLine($" [X] Enviada: {message}");
    }
}