﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCloud.Maps.Client.WebApi
{
    public interface IStorage
    {
        Task<T> Get<T>(string key) where T : class;
    }
}
