﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Domain.Entities;
public class PostErrorActionApiCallConfiguration : BaseEntity
{
    public required string FullPath { get; set; }

    public required string Message { get; set; }
}
