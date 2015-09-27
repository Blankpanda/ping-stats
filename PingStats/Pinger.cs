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
    class Pinger
    {
        public List<long> Replies 
        {
            get { return ReplyTimes; }
            set { Replies = ReplyTimes; }

        }

        private List<long> ReplyTimes = new List<long>(); // used to track the reply times.


        // pings a supplied IP address or domain name
        public void PingAdd(string add)
        {
            add = add.Trim();

            Ping pinger = new Ping();
            long pTime = 0;

            PingReply rep = pinger.Send(add);

            if (rep.RoundtripTime == 0)
            {
                pTime = 0;
            }
            else
            {
                pTime = rep.RoundtripTime;            
            }

        
            ReplyTimes.Add(pTime);
        }

    }
}
