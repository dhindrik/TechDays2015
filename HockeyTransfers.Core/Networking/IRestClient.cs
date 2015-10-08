﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.Core.Networking
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string url);
    }
}
