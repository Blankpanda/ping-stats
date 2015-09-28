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

			Net.IsDomainName("google.com");
			// user entry
			string inAddress = "";
			string inPingAmount = "";

			while (true) // we need to make sure that the user enters in a string or an IP address
			{
				Console.WriteLine("Enter an IP address or a hostname: ");

				try // if the address doesnt throw an error we can check to see if its a valid IP / hostname
				{	        
					inAddress =
					Console.ReadLine();

					// checks if the input is an IP address/domain name, if not then we continue the loop.
					if (Net.IsIPAddress(inAddress))
					{
						break; // true, the string is an IP address
					}
					//else if (Net.IsDomainName(inAddress))
					//{
					//    break; // true, the string is a domain name
					//}
					else
					{
						Console.WriteLine("Invalid address, use x.x.x.x format for IP or a domain name");
						inAddress = "";
						continue; // false, redo the loop.
					}
				}
				catch (Exception)
				{
					// the output is invalid.
					Console.WriteLine("Invalid address, use x.x.x.x format for IP or a domain name");
					inAddress = "";
					continue;				            
				}
				
			}
		  

			Console.WriteLine("Enter in the number of times you want to ping this address");
			 inPingAmount =
			Console.ReadLine();

			// Cast PingAmount to a long
			long PingAmount = long.Parse(inPingAmount);
			
			while (reps.Count <= PingAmount)
			{
				p.PingAdd(inAddress); // send a ICMP message
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
