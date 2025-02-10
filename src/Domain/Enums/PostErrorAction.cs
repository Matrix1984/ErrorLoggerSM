using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Domain.Enums;
public enum PostErrorAction
{
    SEND_EMAIL=0,
    SYSTEM_NOTIFICATION=1,
    API_CALL=2
}
