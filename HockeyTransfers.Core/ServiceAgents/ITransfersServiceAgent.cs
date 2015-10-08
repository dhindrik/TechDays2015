using HockeyTransfers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.Core.ServiceAgents
{
    public interface ITransfersServiceAgent
    {
        Task<List<Transfer>> GetShlAsync();
        Task<List<Transfer>> GetAllsvenskanAsync();
    }

}
