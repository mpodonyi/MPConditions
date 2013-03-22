using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Primitives;

namespace MPConditions
{
    public static class StringConditionsExtensions
    {
        public static IStringCondition Condition(this string value, string name)
        {
            return new StringCondition(value, name);
        }
    }
}
