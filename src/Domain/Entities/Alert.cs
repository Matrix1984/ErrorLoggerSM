using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Domain.Entities;
public class Alert : BaseEntity
{
    public required string Name { get; set; }
    public required ErrorLogType ErrorLogType { get; set; } 
    public int NumberOfOccurences { get; set; }
}
