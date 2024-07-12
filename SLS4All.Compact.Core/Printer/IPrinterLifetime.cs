// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS4All.Compact.Printer
{
    public enum PrinterShutdownMode
    {
        NotSet = 0,
        UpdateApplication,
        ExitApplication,
        ShutdownSystem,
        RebootSystem,
        RestartApplication,
    }

    public sealed record class PrinterLifetimeRequest(PrinterShutdownMode Mode, Func<Task>? Callback = null);

    public interface IPrinterLifetime
    {
        bool IsStopping { get; }
        Task RequestShutdown(PrinterShutdownMode mode, Func<Task>? callback);
        Task PerformShutdown(PrinterLifetimeRequest request);
    }
}
