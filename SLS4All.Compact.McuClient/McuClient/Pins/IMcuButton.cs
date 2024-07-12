// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using SLS4All.Compact.Threading;

namespace SLS4All.Compact.McuClient.Pins
{
    public interface IMcuButton
    {
        string Name { get; }
        AsyncEvent<int> ButtonEvent { get; }
        IMcu Mcu { get; }
    }
}