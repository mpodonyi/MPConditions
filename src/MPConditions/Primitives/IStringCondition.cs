using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    public interface IStringCondition : ICondition<string>, IConditionInternal
    {
        string Subject { get; }

        IStringCondition Or { get; }

        INumberCondition<T, string> AsNumber<T>() where T : struct, IComparable<T>;
    }
}
