using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Application.SeverityLevels.Commands;
public class UpdateSeverityLevelDto
{
    public string? Name { get; init; }

    public string? Level { get; init; }
}
