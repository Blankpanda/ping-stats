using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingStats
{
	class Program
	{
		static void Main(string[] args)
	   {
			Pinger p = new Pinger(); // object of Pinger.cs to get replies and ping addressess
			List<long> reps = new List<long>(); // list of replies
			List<System.Net.NetworkInformation.IPStatus> status = new List<System.Net.NetworkInformation.IPStatus>();


			// user entry
			string inAddress = "";
			string inPingAmount = "";
			long PingAmount = 0;

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
					else if (Net.IsDomainName(inAddress))
					{
						break; // true, the string is a domain name
					}
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
		  
			// makes sure the number of times were pinging is a number.
			while (true)
			{
				Console.WriteLine("Enter in the number of times you want to ping this address");
				try
				{
					
					inPingAmount =
					Console.ReadLine();

					if (long.TryParse(inPingAmount, out PingAmount))
					{
						break;
					}
					else
					{
						Console.WriteLine("Invalid input, try using a number");
						inPingAmount = "";
						continue;
					}
					
				}
				catch (Exception)
				{

					Console.WriteLine("Invalid input, try using a number");
					inPingAmount = "";
					continue;
				}
			
			}

			// Cast inPingAmount to a long
			PingAmount = long.Parse(inPingAmount);

			while (reps.Count <= PingAmount)
			{
				p.PingAddress(inAddress); // send a ICMP message
				reps = p.Replies;  // populate the list with the replies
				Console.WriteLine("Ping #" + reps.Count + " (status): " + p.Responses[reps.Count - 1]); // track the ICMP requests in console.                                                                
			}

		  
			// Use Json.net to organinze a string into json using a list and then create a .json file.
			string json = Json.FormatJson(reps);
			Json.CreateNewJsonFile(json);

			// TODO: we need to get the address/domain name thats being pinged and either put it into a different file or make it the header of the normal json file.

			// create a parallel file that contains information to build the graph.
			//FileWriter writer = new FileWriter();
			//string file = writer.CreateFileName();
			//file = file + "_info"; // we need to signify that this is a different file
			//writer.WriteToFile(file,inAddress);
			

			Console.ReadLine();
	   }
	}
}
