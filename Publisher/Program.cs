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
            "saudacao_1", // nome da fila
            false, // ativo após o servidor ser reiniciado?
            false, // só pode ser acessada na conexão atual?
            false, // é removida após os consumidores utilizarem a fila?
            null);

        var message = "Bem-vindo ao RabbitMQ";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("", "saudacao_1");

        Console.WriteLine($" [X] Enviada: {message}");
    }
}