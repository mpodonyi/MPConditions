using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public abstract class ConditionBase<T, AssertT> where AssertT : ConditionBase<T, AssertT>
    {
        protected T _Value;

        protected Queue<Func<ExecutionContext>> ec = new Queue<Func<ExecutionContext>>();



        //private Condition<T> OrCondition;

        private List<string> _FailedConditions = new List<string>();

        protected bool HasFailed
        {
            get
            {
                return _FailedConditions.Count > 0;
            }
        }



        internal ConditionBase(T value, string name)
        {
            _Value = value;
        }



        public AssertT Or
        {
            get
            {
                ec.Enqueue(() => new ExecutionContext
                {
                    ExecutionType = ExecutionTypes.Or
                });
                return (AssertT)this;
            }
        }


        //private bool TestForOr()
        //{

        //}



        //public Condition<T> Or(Condition<T> orCondition)
        //{

        //    return this;
        //}

        private ExecutionContext GetNextExecutionContext()
        {
            Func<ExecutionContext> funcExecContext1 = null;

            if(ec.Count > 0)
            {
                funcExecContext1 = ec.Dequeue();

                return funcExecContext1();
            }

            return null;
        }


        private ExecutionContext GetFinalExecutionContext()
        {
            ExecutionContext savedexeccontext = null;

            ExecutionContext execcontext = null;
            while((execcontext = GetNextExecutionContext()) != null)
            {

                if(execcontext.ExecutionType.HasFlag(ExecutionTypes.Or))
                {
                    if(savedexeccontext != null)
                    {
                        if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.None))
                        {
                            break;
                        }

                        if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                        {
                            execcontext = GetNextExecutionContext();
                            if(execcontext == null)
                                break;
                            else if(execcontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                            {
                                continue;
                            }
                            else if(execcontext.ExecutionType.HasFlag(ExecutionTypes.None))
                            {
                                savedexeccontext = execcontext;
                                break;
                            }

                        }
                    }

                    continue;
                }

                //-----

                if(savedexeccontext == null)
                {
                    savedexeccontext = execcontext;
                    continue;
                }
                else if(savedexeccontext != null)
                {


                }


                //-----





                if(execcontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                {
                    if(savedexeccontext == null)
                    {
                        savedexeccontext = execcontext;
                        continue;
                    }
                    else if(savedexeccontext != null)
                    {
                        if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                        {
                            break;
                        }
                        else if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.None))
                        {
                            savedexeccontext = execcontext;
                            continue;
                        }
                    }
                }

                //---------

                if(execcontext.ExecutionType.HasFlag(ExecutionTypes.None))
                {
                    if(savedexeccontext == null)
                    {
                        savedexeccontext = execcontext;
                        continue;
                    }
                    else if(savedexeccontext != null)
                    {
                        if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                        {
                            break;
                        }
                        else if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.None))
                        {
                            savedexeccontext = execcontext;
                            continue;
                        }
                    }
                }
            }

            return savedexeccontext;
        }

        public void Throw()
        {







            throw new Exception();
        }

    }
}
