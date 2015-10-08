using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HockeyTransfers.Models
{
    public class Transfer
    {
        public TransferType TransferType { get; set; }
        public DateTime Date { get; set; }
        public string Player { get; set; }
        public string PlayerLink { get; set; }
        public string FromTeam { get; set; }
        public string FromTeamLink { get; set; }
        public string ToTeam { get; set; }
        public string ToTeamLink { get; set; }
        public string SourceLink { get; set; }
    }
}
