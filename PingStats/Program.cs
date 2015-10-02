using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			List<System.Net.NetworkInformation.IPStatus> ipStatus = new List<System.Net.NetworkInformation.IPStatus>();


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

			while (reps.Count < PingAmount)
			{
				p.PingAddress(inAddress); // send a ICMP message
				reps = p.Replies;  // populate the list with the replies
				ipStatus = p.Responses;
				Console.WriteLine("Ping #" + reps.Count + " (status): " + p.Responses[reps.Count - 1]); // track the ICMP requests in console.                                                                
			}

			FileWriter writer = new FileWriter();
			string msFileName = writer.CreateFileName(inAddress);

			// Use Json.net to organinze a string into json using a list and then create a .json file.
			string msData = Json.FormatJson(reps);			
			writer.WriteToFile(msFileName,msData);
			writer.ChangeFileExten(msFileName, ".json");

			// Use Json.net to create a string that is parallel with the first json file that tracks the reply data
			
			// we need to populate the file with string values not IPStatus instances
			List<string> status = new List<string>();
			System.Net.NetworkInformation.IPStatus isSucess  = System.Net.NetworkInformation.IPStatus.Success;
			System.Net.NetworkInformation.IPStatus isFailure = System.Net.NetworkInformation.IPStatus.TimedOut;
			
			for (int i = 0; i < ipStatus.Count; i++)
			{
				if (ipStatus[i] == isSucess )				
					status.Add("Success");				
				else if (ipStatus[i] == isFailure)				
					status.Add("Fail");				
				else				
					status.Add("Other");
				
				
			}

			string resultData = Json.FormatJson(status);

			// I really hate this			
			string ResultFileName = ReverseString(msFileName);
			ResultFileName = ResultFileName + "_" + ReverseString("status");
			ResultFileName = ReverseString(ResultFileName);

			writer.WriteToFile(ResultFileName, resultData);
			writer.ChangeFileExten(ResultFileName, ".json");			

			Console.ReadLine();
	   }

		private static string ReverseString(string FileName)
		{
			char[] cs = FileName.ToCharArray();
			Array.Reverse(cs);
			string NewName = "";

			for (int i = 0; i < cs.Length; i++)
			{
				NewName += cs[i]; // YEEEAAAAH
			}
			return NewName;
		}
	}
}


