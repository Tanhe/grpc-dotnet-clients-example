using System;
using System.Threading.Channels;
using aspnetcore_grpc_server;
using Grpc.Net.Client;

namespace dotnet_client
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var rsp = client.SayHello(new HelloRequest() { Name = "Abernathy" });

            Console.WriteLine(rsp.Message);
        }
    }
}
