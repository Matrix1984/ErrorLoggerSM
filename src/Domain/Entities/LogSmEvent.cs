using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Domain.Entities;
public class LogSmEvent : BaseAuditableEntity
{
    public required string Name { get; set; }
}
