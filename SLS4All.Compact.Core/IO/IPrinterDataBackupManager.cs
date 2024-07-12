// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using SLS4All.Compact.Threading;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SLS4All.Compact.IO
{
    public interface IPrinterDataBackupManager
    {
        Task Backup(string filename, StatusUpdater? status, CancellationToken cancel);
        Task Restore(Stream archiveStream, StatusUpdater? status, CancellationToken cancel);
    }
}