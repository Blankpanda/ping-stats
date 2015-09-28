using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace PingStats
{
	class Net
	{
		// checks if the inputed string is an IP address
		public static bool IsIPAddress(string ipString)
		{
			string[] octs = ipString.Split('.'); // checks to see if the vlaues are in the right format
			if (octs.Length != 4)
			{
				return false;
			}

			byte b = 0; // checks each value in octs to make sure its a valid byte
			for (int i = 0; i < octs.Length; i++)
			{
				if (!byte.TryParse(octs[i], out b))
				{
					return false;
				}
			}

			return true;
		}

		// checks if the inputed string is a domain name

		public static void IsDomainName(string dnString)
		{

			IPHostEntry x = Dns.Resolve(dnString);
			Console.WriteLine(x.AddressList[0]);

		}
	}
}

