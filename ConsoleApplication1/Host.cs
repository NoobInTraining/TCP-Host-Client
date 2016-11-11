using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Host
    {

        private TcpListener socketHost;

        /// <summary>
        /// Konstruktor that starts the server
        /// </summary>
        /// <param name="iPort"></param>
        public Host(int iPort)
        {
            //The Socket which defines the port where it will listen
            socketHost = new TcpListener(IPAddress.Any, iPort);
        }

        /// <summary>
        /// Method to start the server
        /// </summary>
        public void startServer()
        {            
            bool runServer = true;

            //While we shall accept incomming requests
            while (runServer)
            {
                try
                {
                    //Accept incomming connection requests
                    var client = socketHost.AcceptTcpClient();
                    //set the streams
                    StreamReader clientIn = new StreamReader(client.GetStream());
                    StreamWriter clientOut = new StreamWriter(client.GetStream());

                    //Communicate with client
                    bool clientCommunicate = true;
                    while (clientCommunicate)
                    {
                        //read in the command and process it
                        string clientCommand = clientIn.ReadLine().Trim();
                        switch(clientCommand)
                        {
                            case "stop server":
                                runServer = false;
                                clientCommunicate = false;
                                break;
                            case "stop communication":
                                clientCommunicate = false;
                                break;
                            default:
                                clientOut.WriteLine("Didn't recive valid command!");
                                break;
                        }
                    }
                }
                catch(Exception)
                {
                    //Log the error or handle it in any other way you want.
                }
            }
        }
    }
}
