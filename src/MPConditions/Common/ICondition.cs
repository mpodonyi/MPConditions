using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public interface ICondition<T>
    {
        ExecutionContext GetResult();
    }
}
