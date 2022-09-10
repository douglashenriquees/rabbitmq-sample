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

    }
}