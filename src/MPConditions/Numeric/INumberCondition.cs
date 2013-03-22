using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public interface INumberCondition<T, TPassthrough> : ICondition<TPassthrough>
        //where T : struct, IComparable<T>
    {
        T Subject { get; }

        INumberCondition<T, TPassthrough> Or { get;}
    }
}
