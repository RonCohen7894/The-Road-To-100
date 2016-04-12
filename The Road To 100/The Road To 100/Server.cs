using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace The_Road_To_100
{
    class Server
    {
        public static string GetIpAdress()
        {
            IPHostEntry myHost;
            string ip = "?";
            myHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in myHost.AddressList)
            {
                if (ipa.AddressFamily.ToString() == "InterNetwork")
                    ip = ipa.ToString();
            }
            return ip;
        }

        public static void startServer()
        {
            Console.WriteLine("[*] Opening server...");
            TcpListener listener = new TcpListener(IPAddress.Any, 45784);
            listener.Start();
            Console.WriteLine("[*] Server waiting on port " + 45784);
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            StreamReader STR = new StreamReader(client.GetStream());
            Console.WriteLine(STR.ReadLine());
        }

        public void main()
        {
            string ip = GetIpAdress();
            Console.WriteLine("server on: " + ip);
            startServer();
            Console.Read();
        }
    }
}
