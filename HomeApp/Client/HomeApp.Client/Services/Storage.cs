﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeApp.Client.Services
{
    public class Storage : IStorage
    {
        private readonly IJSRuntime _runtime;

        public Storage(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public async Task<T> Get<T>(string key)
            where T : class
        {
            string json = await _runtime.InvokeAsync<string>("sessionStorage.getItem", key);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
