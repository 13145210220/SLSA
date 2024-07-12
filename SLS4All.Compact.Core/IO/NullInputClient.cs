// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SLS4All.Compact.Diagnostics;
using SLS4All.Compact.IO;
using SLS4All.Compact.Power;
using SLS4All.Compact.Printer;
using SLS4All.Compact.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SLS4All.Compact.Power
{
    public sealed class NullInputClient : IInputClient
    {
        public static NullInputClient Instance { get; } = new();
        public string SafeButtonId => "SAFE_BUTTON";
        public string LidClosedId => "SAFE_BUTTON";
        public InputState CurrentState { get; } = new InputState([]);
        public AsyncEvent<InputState> StateChangedLowFrequency { get; } = new();
        public AsyncEvent<InputState> StateChangedHighFrequency { get; } = new();
    }
}
