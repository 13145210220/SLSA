// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using Microsoft.Extensions.Logging;
using SLS4All.Compact.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS4All.Compact.TestPlugin
{
    public class PluginWatchdog : IPrinterWatchDogMonitor
    {
        private readonly ILogger _logger;

        public bool IsEnabled => false;

        public PluginWatchdog(ILogger<PluginWatchdog> logger)
        {
            _logger = logger;
            logger.LogInformation("Plugin watchdog created");
        }

        public Task SetEnabled(bool isEnabled, CancellationToken cancel)
        {
            _logger.LogInformation($"Plugin watchdog SetEnabled({isEnabled})");
            return Task.CompletedTask;
        }
    }
}