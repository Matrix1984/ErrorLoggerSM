using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLoggerSM.Domain.Entities;
public class SysError : BaseEntity
{
    public PostErrorActionApiCallConfiguration? ApiCallConfiguration { get; set; }
    public  List<PostErrorAction>? ErrorActions { get; set; }


}
