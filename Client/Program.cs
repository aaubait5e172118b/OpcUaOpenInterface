using System;
using System.Collections.Generic;
using Opc.Ua;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // test
            var client = new Client("127.0.0.1:51210/UA/SampleServer");

            
            List<Node> collectionList = new List<Node>();
            collectionList = Node.Discover(client.Session);
            collectionList = Node.OrderList(collectionList);
  
            foreach (Node node in collectionList)
            {
                Console.WriteLine("displayname : " + node.Description.DisplayName);
            }

            
            client.Kill();
            
            
            
            
            Console.ReadKey();
            
        }
    }
}
