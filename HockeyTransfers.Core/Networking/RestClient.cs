using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.Core.Networking
{
    public class RestClient : IRestClient
    {
        public Task<T> GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }
    }
}
