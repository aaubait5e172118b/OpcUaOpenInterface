using System;

using Opc.Ua;

namespace OpcUaOpenInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var webserver = new web.Server();
            var opcClient = new opcClient.Client("opc.tcp://" + Utils.GetHostName() + ":51210/UA/SampleServer");
        }
    }
}
