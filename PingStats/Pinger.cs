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

        public List<IPStatus> Responses
        {
            get { return Responded; }
            set { Responses = Responded; }
        }


        private List<long> ReplyTimes = new List<long>(); // used to track the reply times.
        private List<IPStatus> Responded = new List<IPStatus>();

        // pings a supplied IP address or domain name and populate a list with the roundtimetrip
        public void PingAddress(string add)
        {
            add = add.Trim();

            Ping pinger = new Ping();
            long pTime = 0;

            PingReply rep = pinger.Send(add); //sends and IMCP message

            if (rep.RoundtripTime == 0)
                pTime = 0;
            else
                pTime = rep.RoundtripTime;
            

            Responded.Add(rep.Status);
            ReplyTimes.Add(pTime);


        }

    }
}
