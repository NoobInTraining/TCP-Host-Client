using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Host
    {
        public Host(int iPort)
        {
            var socketHost = new TcpListener(IPAddress.Any, iPort);
            bool runServer = true;

            while (runServer)
            {
                try
                {
                    //Get the client
                    var client = socketHost.AcceptTcpClient();
                    StreamReader a;

                    bool clientCommunicate = true;
                    while (clientCommunicate)
                    {

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
