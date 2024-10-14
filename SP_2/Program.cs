using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SP_2
{
    class Program
    {
        static async Task Main()
        {
            using (var udpClient = new UdpClient(8001))
            {
                var brodcastAddress = IPAddress.Parse("235.5.5.11");//хост для отправки данных

                udpClient.JoinMulticastGroup(brodcastAddress, 50);
                while (true)
                {
                    var result = await udpClient.ReceiveAsync();
                    string message = Encoding.UTF8.GetString(result.Buffer);
                    
                    Console.WriteLine(message);
                }

                udpClient.DropMulticastGroup(brodcastAddress);
            }
            Console.ReadLine();
        }
    }
}
