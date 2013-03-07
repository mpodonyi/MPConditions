using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    [Flags]
    public enum ExecutionTypes
    {
        None = 0x0,
        Or = 0x1,
        OutOfRange = 0x2,
        Error = OutOfRange,
    }
}
