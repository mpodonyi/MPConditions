using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    [Flags]
    public enum ExecutionTypes
    {
        None = 0x1,
        Or = 0x2,
        OutOfRange = 0x4,
        StartsWith =0x8,
        WrongType = 0x16,

        Error = OutOfRange | StartsWith | WrongType,
    }
}
