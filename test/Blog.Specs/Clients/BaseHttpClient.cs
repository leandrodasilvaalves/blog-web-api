using Refit;

namespace Blog.Specs.Clients
{
    public class BaseHttpClient
    {
        public static TcpClient Create<TcpClient>() => RestService.For<TcpClient>("http://localhost:5326/api/v1");
    }
}