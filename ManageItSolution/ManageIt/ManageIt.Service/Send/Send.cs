using RabbitMQ.Client;

namespace ManageIt.Service.Send
{
    public class Send
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    
                }
            }
        }
    }
}
