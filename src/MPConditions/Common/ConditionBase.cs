using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public abstract class ConditionBase<TValue> : ICondition<TValue>, IFluentInterface
    {

        
        public TValue SubjectValue
        {
            get;
            private set;
        }

        private object _OriginalSubjectValue;
        object ICondition.OriginalSubjectValue { get { return _OriginalSubjectValue; } }
        
        public string SubjectName
        {
            get;
            private set;
        }

        private Queue<Func<ValidationInfo>> ec = new Queue<Func<ValidationInfo>>(3);

        internal ConditionBase(TValue subjectValue, string subjectName)
        {
            SubjectValue = subjectValue;
            SubjectName = subjectName;
        }

        internal void MergeIn<TOldValue>(ConditionBase<TOldValue> previousCondition)
        {
            _OriginalSubjectValue = previousCondition.SubjectValue;
            ec = new Queue<Func<ValidationInfo>>(previousCondition.ec);
        }

        void ICondition.Push(Func<Common.ValidationInfo> action)
        {
            _ValidationResultCache = null;
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
        
        private ValidationInfo _ValidationResultCache = null;
        public ValidationInfo GetResult()
        {
            return _ValidationResultCache = _ValidationResultCache ?? GetFinalExecutionContext() ?? ValidationInfo.Empty;
        }
    }
}
