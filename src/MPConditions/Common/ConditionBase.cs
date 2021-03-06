﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    internal abstract class ConditionBase<TValue, TOriginalValue> : ICondition<TOriginalValue>, IConditionInternal
    //where AssertT : ConditionBase<T, V>
    {
        protected TValue _Value;
        public TOriginalValue OriginalValue { get; private set; }
        protected string _ArgumentName;

        protected Queue<Func<ExecutionContext>> ec = new Queue<Func<ExecutionContext>>();

        internal void MerginQueue(Queue<Func<ExecutionContext>> executionContext)
        {
            foreach(var item in executionContext)
                ec.Enqueue(item);
            // return (AssertT)this;
        }

        internal ConditionBase(TValue value, TOriginalValue originalValue, string name)
        {
            OriginalValue = originalValue;
            _Value = value;
            _ArgumentName = name;
        }

        public ConditionBase<TValue, TOriginalValue> Or
        {
            get
            {
                ec.Enqueue(() => ExecutionContext.Or);
                return this;
            }
        }

        public void Push(Func<Common.ExecutionContext> action)
        {
            ec.Enqueue(action);
        }

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

        public ExecutionContext GetResult()
        {
            ExecutionContext execcontext = GetFinalExecutionContext() ?? ExecutionContext.Empty;

            //execcontext.SetNameAndValue(_ArgumentName, _OriginalValue);

            return execcontext;
        }




    }
}
