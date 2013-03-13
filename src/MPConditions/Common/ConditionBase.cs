using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public abstract class ConditionBase<T, V, AssertT> : ICondition<V>
        where AssertT : ConditionBase<T, V, AssertT>
    {
        protected T _Value;
        protected V _OriginalValue;
        protected string _ArgumentName;



        protected Queue<Func<ExecutionContext<V>>> ec = new Queue<Func<ExecutionContext<V>>>();



        //private Condition<T> OrCondition;

        internal AssertT MerginQueue(Queue<Func<ExecutionContext<V>>> executionContext)
        {
            foreach(var item in executionContext)
                ec.Enqueue(item);
            return (AssertT)this;
        }




        internal ConditionBase(T value, V originalValue, string name)
        {
            _OriginalValue = originalValue;
            _Value = value;
            _ArgumentName = name;
        }



        public AssertT Or
        {
            get
            {
                ec.Enqueue(() => ExecutionContext<V>.Or);
                return (AssertT)this;
            }
        }


        private ExecutionContext<V> GetNextExecutionContext()
        {
            Func<ExecutionContext<V>> funcExecContext1 = null;

            if(ec.Count > 0)
            {
                funcExecContext1 = ec.Dequeue();

                return funcExecContext1();
            }

            return null;
        }


        private ExecutionContext<V> GetFinalExecutionContext()
        {
            ExecutionContext<V> savedexeccontext = null;

            ExecutionContext<V> execcontext = null;
            while((execcontext = GetNextExecutionContext()) != null)
            {
                if(execcontext.ExecutionType == ExecutionTypes.Or)
                {
                    if(savedexeccontext != null)
                    {
                        if(savedexeccontext.ExecutionType == ExecutionTypes.None)
                        {
                            break;
                        }

                        if(savedexeccontext.ExecutionType == ExecutionTypes.Error)
                        {
                            do
                            {
                                execcontext = GetNextExecutionContext();
                            } while(execcontext != null && execcontext.ExecutionType == ExecutionTypes.Or); //fix for ---> X.Or.Or.Y

                            if(execcontext == null)
                                break;
                            else if(execcontext.ExecutionType == ExecutionTypes.Error)
                            {
                                if(execcontext.FailFast)
                                    break;

                                continue;
                            }
                            else if(execcontext.ExecutionType == ExecutionTypes.None)
                            {
                                savedexeccontext = execcontext;
                                continue;
                            }
                        }
                    }

                    continue;
                }

                //-----

                if(execcontext.ExecutionType == ExecutionTypes.Error)
                {
                    if(savedexeccontext == null)
                    {
                        savedexeccontext = execcontext;
                        if(execcontext.FailFast)
                            break;

                        continue;
                    }
                    else if(savedexeccontext != null)
                    {
                        if(savedexeccontext.ExecutionType == ExecutionTypes.Error)
                        {
                            break;
                        }
                        else if(savedexeccontext.ExecutionType == ExecutionTypes.None)
                        {
                            savedexeccontext = execcontext;
                            if(execcontext.FailFast)
                                break;

                            continue;
                        }
                    }
                }

                //---------

                if(execcontext.ExecutionType == ExecutionTypes.None)
                {
                    if(savedexeccontext == null)
                    {
                        savedexeccontext = execcontext;
                        continue;
                    }
                    else if(savedexeccontext != null)
                    {
                        if(savedexeccontext.ExecutionType == ExecutionTypes.Error)
                        {
                            break;
                        }
                        else if(savedexeccontext.ExecutionType == ExecutionTypes.None)
                        {
                            savedexeccontext = execcontext;
                            continue;
                        }
                    }
                }
            }

            return savedexeccontext;
        }

        //private IDictionary<ExecutionTypes, Type> ExceptionMapping = new Dictionary<ExecutionTypes, Type>(5)
        //    {
        //        {ExecutionTypes.OutOfRange,typeof(ArgumentOutOfRangeException) },
        //        {ExecutionTypes.StartsWith,typeof(ArgumentException) }
        //     };  

        public ExecutionContext<V> GetResult()
        {
            ExecutionContext<V> execcontext = GetFinalExecutionContext();

            return ExecutionContext<V>.CopyFrom(_ArgumentName, _OriginalValue, execcontext);
        }




    }
}
