using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Client
    {
        private TcpClient client;
        private StreamReader clientIn;
        private StreamWriter clientOut;

        /// <summary>
        /// Sets the connection to the Host
        /// </summary>
        /// <param name="host">The IP of the Host</param>
        /// <param name="iPort">The Port on which the host is lsitning</param>
        public Client(string host, int iPort)
        {
            //conenct and set the streams
            client = new TcpClient(host, iPort);
            clientIn = new StreamReader(client.GetStream());
            clientOut = new StreamWriter(client.GetStream());
            clientOut.AutoFlush = true;
        }

        /// <summary>
        /// Writes message to the server
        /// </summary>
        /// <param name="msg">The message</param>
        public void sendToServer(string msg)
        {
            clientOut.WriteLine(msg);
        }

        /// <summary>
        /// Blocks until it recieves a message from the server
        /// </summary>
        /// <returns>The message from the server</returns>
        public string recieveFromServer()
        {
            return clientIn.ReadLine();
        }
    }
}
