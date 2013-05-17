using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public abstract class ConditionBase<TValue> : ICondition<TValue>
    {

        private TValue _Subject;
        public TValue Subject
        {
            get { return _Subject; }
        }

        private object _OriginalSubject;
        object ICondition.OriginalSubject { get { return _OriginalSubject; } }

        private string _SubjectName;
        public string SubjectName { get { return _SubjectName; } }

        private Queue<Func<ValidationInfo>> ec = new Queue<Func<ValidationInfo>>(3);

        internal ConditionBase(TValue value, string subjectName)
        {
            _OriginalSubject = value;
            _Subject = value;
            _SubjectName = subjectName;
        }

        internal ConditionBase(TValue value, string subjectName, object originalSubject)
        {
            _Subject = value;
            _OriginalSubject = originalSubject;
            _SubjectName = subjectName;
        }

        internal void MergeIn<TOldValue>(ConditionBase<TOldValue> previousCondition)
        {
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
