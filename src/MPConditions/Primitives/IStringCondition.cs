using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Primitives
{
    public interface IStringCondition : ICondition<string>
    {
        string Subject { get; }

        void Push(Func<ExecutionContext> action);
    }
}
