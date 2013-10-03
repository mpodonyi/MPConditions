using System;
using System.Collections.Generic;


namespace MPConditions.Common
{
    public abstract class ConditionBase<TValue, TOriginal> : IFluentInterface
    {
        public string SubjectName
        {
            get;
            private set;
        }

        protected TValue SubjectValue
        {
            get;
            private set;
        }

        public TOriginal OriginalSubjectValue
        {
            get;
            private set;
        }



        private Queue<Func<ValidationInfo>> ec = new Queue<Func<ValidationInfo>>(3);

        protected ConditionBase(TValue subjectValue, object originalValue, string subjectName)
        {
            SubjectValue = subjectValue;
            SubjectName = subjectName;
            OriginalSubjectValue = (TOriginal)originalValue;
        }

        internal void MergeIn<WhatEver>(ConditionBase<WhatEver, TOriginal> previousCondition)
        {
            OriginalSubjectValue = previousCondition.OriginalSubjectValue;
            ec = new Queue<Func<ValidationInfo>>(previousCondition.ec);
        }

        protected void Push(Func<Common.ValidationInfo> action)
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
