using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Domain.Entities;
public class SeverityLevel : BaseEntity
{
    public required string Name { get; set; }
}
