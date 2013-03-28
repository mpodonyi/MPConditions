using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    /// <summary>
    /// The base interface for all numeric values under validation.
    /// </summary>
    /// <typeparam name="T">The numeric type under validation.</typeparam>
    /// <typeparam name="TPassthrough">The type of the original value.</typeparam>
    public interface INumberCondition<T, TPassthrough> : ICondition, IConditionInternal
        where T : struct, IComparable<T>
    {
         T Subject { get; }

        INumberCondition<T, TPassthrough> Or { get;}
    }
}
