using System;
using aspnetcore_grpc_server;
using Grpc.Core;

namespace netframework_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var methods = new Action[] { BasicAttempt, WithDefaultSslCredentials };

            foreach (var method in methods)
            {
                try
                {
                    Console.Write($"Attempting {method.Method.Name}...");
                    method();
                    Console.WriteLine("Success!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failure :(");
                    Console.WriteLine(e.ToString());
                    Console.WriteLine();
                }
            }
        }

        private static void BasicAttempt()
        {
            var channel = new Channel("localhost", 5001, ChannelCredentials.Insecure);
            
            var client = new Greeter.GreeterClient(channel);

            var rsp = client.SayHello(new HelloRequest() {Name = "Abernathy"});

            Console.WriteLine(rsp);
        }
        
        private static void WithDefaultSslCredentials()
        {
            var channel = new Channel("localhost", 5001, new SslCredentials());
            
            var client = new Greeter.GreeterClient(channel);

            var rsp = client.SayHello(new HelloRequest() {Name = "Abernathy"});

            Console.WriteLine(rsp);
        }
    }
}
