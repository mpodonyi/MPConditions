using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    internal static class Helper
    {
        public static bool HasFlag(this ExecutionTypes value, ExecutionTypes flag)
        {
            return (value & flag) > 0;
        }
    }
}
