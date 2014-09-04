using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClientSample
{
    class Program
    {
        static List<string> ids = new List<string>(); 
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:38507/");
            IHubProxy locationsHub = hubConnection.CreateHubProxy("LocationsHub");

            hubConnection.Start().Wait();

            locationsHub.On<string>("hello", myString =>
            {
                Console.WriteLine("This is client getting messages from server :{0}", myString);
                Console.ReadLine();
            });
            locationsHub.On<string>("pushIds", id =>
            {
              ids.Add(id);
            });
           var val = Console.ReadLine();
           locationsHub.Invoke("Hello", ids[0], val);
           Console.ReadLine();
        }

         
    }
}
