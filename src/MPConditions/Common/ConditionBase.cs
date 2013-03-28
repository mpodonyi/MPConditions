using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    internal abstract class ConditionBase<TValue, TOriginalValue> : ICondition, IConditionInternal
    //where AssertT : ConditionBase<T, V>
    {
        protected TValue _Value;
        public object OriginalSubject { get; private set; }
        public string SubjectName { get; private set; }

        protected Queue<Func<ValidationInfo>> ec = new Queue<Func<ValidationInfo>>(3);

        protected ConditionBase(TValue value, TOriginalValue originalValue, string name)
        {
            OriginalSubject = originalValue;
            _Value = value;
            SubjectName = name;
        }

        protected ConditionBase(TValue value, ConditionBase<TOriginalValue, TOriginalValue> previousCondition)
        {
            OriginalSubject = previousCondition.OriginalSubject;
            _Value = value;
            SubjectName = previousCondition.SubjectName;
            ec = new Queue<Func<ValidationInfo>>(previousCondition.ec);
        }


        public ConditionBase<TValue, TOriginalValue> Or
        {
            get
            {
                ec.Enqueue(() => ValidationInfo.Or);
                return this;
            }
        }

        public void Push(Func<Common.ValidationInfo> action)
        {
            ec.Enqueue(action);
        }

        private ValidationInfo GetNextExecutionContext()
        {
            Func<ValidationInfo> funcExecContext1 = null;

            if(ec.Count > 0)
            {
                funcExecContext1 = ec.Dequeue();

                return funcExecContext1() ?? ValidationInfo.Empty;
            }

            return null;
        }


        private ValidationInfo GetFinalExecutionContext()
        {
            ValidationInfo savedexeccontext = null;

            ValidationInfo execcontext = null;
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

        public ValidationInfo GetResult()
        {
            ValidationInfo execcontext = GetFinalExecutionContext() ?? ValidationInfo.Empty;

            //execcontext.SetNameAndValue(_ArgumentName, _OriginalValue);

            return execcontext;
        }




    }
}
