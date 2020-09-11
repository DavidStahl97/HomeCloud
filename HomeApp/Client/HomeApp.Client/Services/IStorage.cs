﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Client.Services
{
    public interface IStorage
    {
        Task<T> Get<T>(string key) where T : class;
    }
}
