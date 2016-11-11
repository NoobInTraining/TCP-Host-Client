using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //initilize and start the server
            var host = new Host(13243);
            var server = new Task(host.startServer);
            server.Start();

            //connect to the server
            var client = new Client("", 13243);
            //end send varius messages
            client.sendToServer("Hello");
            Console.WriteLine(client.recieveFromServer());
            client.sendToServer("stop communication");
            //from now on any interaction with the client would cause an error            
            Console.WriteLine(client.recieveFromServer());
        }
    }
}
