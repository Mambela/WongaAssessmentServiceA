using RabbitMQ.Client;


string name;

try
{


    var factory = new ConnectionFactory();
    factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
    var connection = factory.CreateConnection();
    var channel = connection.CreateModel();

    channel.ExchangeDeclare("communicationExchange", ExchangeType.Direct, true);


    Console.WriteLine("Please enter your name");
    name = Console.ReadLine();


    var message = $"Hello my name is, {name}";
    var bytes = System.Text.Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("communicationExchange", "communicate.Name", null, bytes);

    channel.Close();
    connection.Close();


    Console.WriteLine("Press enter to exit.");
    Console.ReadLine();

}
catch (Exception ex)
{

    throw ex;
}