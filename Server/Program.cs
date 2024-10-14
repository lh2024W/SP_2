using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static async Task Main()
        {
            var messages = new string[] { "Жизнь — это то, что с тобой происходит, пока ты строишь планы. Джон Леннон",
                "Стремитесь не к успеху, а к ценностям, которые он дает. Альберт Эйнштейн",
                "Сначала мечты кажутся невозможными, затем неправдоподобными, а потом неизбежными. Кристофер Рив",
                "Лучшая месть — огромный успех. Фрэнк Синатра",
                "Талант — это дар, которому невозможно ни научить, ни научиться. Иммануил Кант",
                "Единственный способ делать свою работу хорошо — это любить ее. Если ты еще не нашел свое любимое дело, продолжай искать. Стив Джобс"};
            var brodcastAddress = IPAddress.Parse("235.5.5.11");
            using var udpSender = new UdpClient();
            Random rand = new Random();
            
            foreach (var message in messages)
            {
                Console.WriteLine($"A message is being sent: {rand.Next(messages.Length)}");
                byte[] data = Encoding.UTF8.GetBytes(message);
                await udpSender.SendAsync(data, new IPEndPoint(brodcastAddress, 8001));
                await Task.Delay(1000);
            }
            Console.ReadLine();
        }
    }
}
