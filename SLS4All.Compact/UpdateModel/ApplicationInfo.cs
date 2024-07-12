// Copyright(C) 2024 anyteq development s.r.o.
// 
// This file is part of SLS4All project (sls4all.com) and is made available
// under the terms of the License Agreement as described in the LICENSE.txt
// file located in the root directory of the repository.

﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SLS4All.Compact.UpdateModel
{
    public record class ApplicationInfo
    {
        public required ApplicationIdentity Identity { get; set; }
        public required string ArchiveFormat { get; set; }
        public required string ArchiveUri { get; set; }
        public required DateTimeOffset PublishedAt { get; set; }
        public long? ArchiveSize { get; set; }
        public string? ReleaseNotesUrl { get; set; }
    }
}
