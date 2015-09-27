using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PingStats
{
    class Program
    {
        static void Main(string[] args)
       {
            Pinger p = new Pinger(); // object of Pinger.cs to get replies and ping addressess
            List<long> reps = new List<long>(); // list of replies

            // Input

            Console.WriteLine("Enter an IP address or a hostname: ");
            string Address = 
            Console.ReadLine();

            Console.WriteLine("Enter in the number of times you want to ping this address");
            string inPingAmount =
            Console.ReadLine();

            // Cast PingAmount to a long
            long PingAmount = long.Parse(inPingAmount);
            
            while (reps.Count <= PingAmount)
            {
                p.PingAdd(Address); // send a ICMP message
                reps = p.Replies;  // populate the list with the replies                                                                                
            }

            // Use Json.net to convert the List into a .json file.
            string json = JsonConvert.SerializeObject(reps.ToArray(), Formatting.Indented);

            // write the formatted JSON to a created file.
            FileWriter writer = new FileWriter();

            string writeFile = writer.CreateFileName();
            writer.WriteToFile(writeFile, json);

            // change the file to JSON format
            writer.ChangeFileExten(writeFile,".json");

            Console.ReadLine();
        }
    }
}
