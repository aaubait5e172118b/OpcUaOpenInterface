using System;

using Opc.Ua;

using Client.Connection;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // test
            var client = new Client("127.0.0.1:51210/UA/SampleServer");

            Console.ReadKey();
            client.Kill();
        }
    }
}
