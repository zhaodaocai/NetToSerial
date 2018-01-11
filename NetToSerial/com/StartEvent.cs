using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace com
{
    public class StartEvent
    {
       protected AutoResetEvent mCanStart = new AutoResetEvent(true);

    }
}
