using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //initilize and start the server
            var host = new Host(13243);
            var server = new Thread(host.startServer);
            server.Start();
            //Wait till server is up and runing
            while (!server.IsAlive) ;
            
            //connect to the server
            var client = new Client("", 13243);
            //end send varius messages
            client.sendToServer("Hello");
            Console.WriteLine(client.recieveFromServer());
            client.sendToServer("stop communication");                 
            Console.WriteLine(client.recieveFromServer());

            //using that same client object would now result in an error, eversicne the server has stopped communcation, 
            //so now we would need to reinsatiate that client to communicate with the server again.
        }
    }
}
