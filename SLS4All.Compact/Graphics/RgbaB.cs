// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using System.Globalization;

namespace SLS4All.Compact.Graphics
{
    public record struct RgbaB(byte R, byte G, byte B, byte A)
    {
        public string CssString => string.Create(CultureInfo.InvariantCulture, $"rgba({R}, {G}, {B}, {A / 255.0f})");
    }
}