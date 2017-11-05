using System;

using Opc.Ua;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("opc.tcp://" + Utils.GetHostName() + ":51210/UA/SampleServer");
        }
    }
}
