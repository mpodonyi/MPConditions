using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public abstract class ConditionBase<T, AssertT> where AssertT : ConditionBase<T, AssertT>
    {
        protected T _Value;
        protected string _ArgumentName;

        protected Queue<Func<ExecutionContext>> ec = new Queue<Func<ExecutionContext>>();



        //private Condition<T> OrCondition;

        internal AssertT MerginQueue(Queue<Func<ExecutionContext>> executionContext)
        {
            foreach(var item in executionContext)
                ec.Enqueue(item);
            return (AssertT)this;
        }
      



        internal ConditionBase(T value, string name)
        {
            _Value = value;
            _ArgumentName = name;
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
                            do
                            {
                                execcontext = GetNextExecutionContext();
                            } while(execcontext != null && execcontext.ExecutionType.HasFlag(ExecutionTypes.Or)); //fix for ---> X.Or.Or.Y
                            
                            if(execcontext == null)
                                break;
                            else if(execcontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                            {
                                if(execcontext.FailFast)
                                    break;

                                continue;
                            }
                            else if(execcontext.ExecutionType.HasFlag(ExecutionTypes.None))
                            {
                                savedexeccontext = execcontext;
                                continue;
                            }
                        }
                    }

                    continue;
                }

                //-----

                if(execcontext.ExecutionType.HasFlag(ExecutionTypes.Error))
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
                        if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.Error))
                        {
                            break;
                        }
                        else if(savedexeccontext.ExecutionType.HasFlag(ExecutionTypes.None))
                        {
                            savedexeccontext = execcontext;
                            if(execcontext.FailFast)
                                break;

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

        //private IDictionary<ExecutionTypes, Type> ExceptionMapping = new Dictionary<ExecutionTypes, Type>(5)
        //    {
        //        {ExecutionTypes.OutOfRange,typeof(ArgumentOutOfRangeException) },
        //        {ExecutionTypes.StartsWith,typeof(ArgumentException) }
        //     };  


        public void Throw()
        {
            ExecutionContext execcontext = GetFinalExecutionContext();

            if(execcontext == null || execcontext.ExecutionType == ExecutionTypes.None)
                return;

            string message=string.Format("Argument '{0}' with value '{1}': {2}",_ArgumentName,_Value, execcontext.Message);

            throw new ConditionException(_ArgumentName, message, execcontext.ExecutionType);


            //switch(execcontext.ExecutionType)
            //{
            //    case ExecutionTypes.OutOfRange:
            //        throw new ArgumentOutOfRangeException(_ArgumentName, message);
            //}

            
        }

    }
}
