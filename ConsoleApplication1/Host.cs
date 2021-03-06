﻿using System;
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
            socketHost.Start();
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
                    clientOut.AutoFlush = true;

                    //Communicate with client
                    bool clientCommunicate = true;
                    while (clientCommunicate)
                    {
                        //read in the command and process it
                        string clientCommand = clientIn.ReadLine().Trim();
                        switch(clientCommand)
                        {
                            case "stop server":
                                clientOut.WriteLine("Stopping server");
                                runServer = false;
                                clientCommunicate = false;
                                //dont need to close anything cause right now server will end and run out of scope
                                break;
                            case "stop communication":
                                clientOut.WriteLine("Stopping communication");
                                clientCommunicate = false;
                                //don't need to clsoe this end, because it would run out of scope anyway but...
                                client.Close();
                                break;
                            default:
                                clientOut.WriteLine("Didn't recive valid command!");
                                break;
                        }
                    }
                }
                catch(Exception ex )
                {
                    //Log the error or handle it in any other way you want.
                }
            }
        }
    }
}
