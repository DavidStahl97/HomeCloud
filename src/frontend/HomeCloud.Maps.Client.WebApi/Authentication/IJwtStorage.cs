﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCloud.Maps.Client.WebApi.Authentication
{
    public interface IJwtStorage
    {
        Task<UserIdentity> Get();
    }
}
