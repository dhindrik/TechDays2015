using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyTransfers.Models;

using System.Xml.Linq;
using System.Net.Http;

namespace HockeyTransfers.Core.ServiceAgents
{
    public class TransfersServiceAgent : ITransfersServiceAgent
    {
      

     

        public async Task<List<Transfer>> GetShlAsync()
        {

            var shlTransfers = await GetTransfers("http://eliteprospects.com/rss_league.php?league=1");

            var transfers = Parse(shlTransfers, TransferType.Unknown);

            return transfers.OrderByDescending(x => x.Date).ToList();
        }


        public async Task<List<Transfer>> GetAllsvenskanAsync()
        {
           
            var haTransfers = await GetTransfers("http://eliteprospects.com/rss_league.php?league=2");

            var transfers = Parse(haTransfers, TransferType.Unknown);

            return transfers.OrderByDescending(x => x.Date).ToList();
        }

        private async Task<string> GetTransfers(string url)
        {
            var client = new HttpClient();

            var bytes =  await client.GetByteArrayAsync(url);

            var xmlString = Encoding.GetEncoding("ISO8859-1").GetString(bytes, 0, bytes.Length);

            return xmlString;
        }

        private List<Transfer> Parse(string xml, TransferType transferType)
        {
            var transfers = new List<Transfer>();

            var element = XElement.Parse(xml);

            var nodes = element.Descendants("item");

            foreach (var node in nodes)
            {
                var transfer = new Transfer();

                var description = node.Element("description").Value;

                if (transferType != TransferType.Unknown)
                {
                    transfer.TransferType = transferType;
                }
                else
                {
                    var st = description.IndexOf("Status:") + 7;
                    var val = description.Substring(st);
                    val = val.Substring(0, val.IndexOf("<br")).Trim();

                    if (!string.IsNullOrWhiteSpace(val))
                    {
                        transferType = (TransferType)Enum.Parse(typeof(TransferType), val); 
                    }

                }


                var start = description.IndexOf("Date:") + 5;
                var str = description.Substring(start);
                str = str.Substring(0, str.IndexOf("<br"));

                transfer.Date = DateTime.Parse(str.Trim());

                start = description.IndexOf("Player:") + 7;
                str = description.Substring(start);


                transfer.Player = GetValueFromATag(str);
                transfer.PlayerLink = GetHrefFromATag(str);

                start = description.IndexOf("To:") + 3;
                str = description.Substring(start);

                transfer.ToTeam = GetValueFromATag(str);
                var url = GetHrefFromATag(str);
                transfer.ToTeamLink = url != null ? "http://eliteprospects.com/" + url : null;

                start = description.IndexOf("From:") + 5;
                str = description.Substring(start);

                transfer.FromTeam = GetValueFromATag(str);
                url = GetHrefFromATag(str);
                transfer.FromTeamLink = url != null ? "http://eliteprospects.com/" + url : null;

                start = description.IndexOf("Source:") + 7;
                str = description.Substring(start);

                transfer.SourceLink = GetHrefFromATag(str);

                transfers.Add(transfer);
            }

            return transfers;
        }

        private string GetValueFromATag(string atag)
        {
            if (atag.Contains("<a") && atag.IndexOf("<a") < 5)
            {
                var str = atag.Substring(atag.IndexOf(">") + 1);
                str = str.Substring(0, str.IndexOf("</a>"));
                return str;
            }


            return string.Empty;
        }

        private string GetHrefFromATag(string atag)
        {
            if (atag.Contains("<a"))
            {
                var link = atag.Substring(atag.IndexOf("href=\"") + 6);
                link = link.Substring(0, link.IndexOf("\""));

                return link;
            }
            else
                return null;
        }

     

    }
}
