using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public interface INullableNumberCondition<T, TPassthrough> : ICondition, IConditionInternal
         where T : struct, IComparable<T>
    {
         T? Subject { get; }

        //void Push(Func<ExecutionContext> action);

         INullableNumberCondition<T, TPassthrough> Or { get; }
    }


    //public interface INumberCondition<T, TPassthrough> 
    //    where T : struct, IComparable<T>
    //{
    //    T Subject { get; }

    //    INumberCondition<T, TPassthrough> Or { get; }
    //}
}
