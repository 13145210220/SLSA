// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using SLS4All.Compact.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SLS4All.Compact.Printer
{
    public interface IPrinterClientInitializer
    {
        Task InitializePrinter(CancellationToken cancel) => Task.CompletedTask;
        Task InitializeClient(IPrinterClient client, IPrinterClientCommandContext? context, CancellationToken cancel);
    }
}
