using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    //[Serializable()]
    public class ConditionException : Exception
    {
        private readonly bool messageExplicit = false;

        public ConditionException() : base() { }

        public ConditionException(string message)
            : base(message)
        {
            messageExplicit = !string.IsNullOrEmpty(message);
        }

        public ConditionException(string message, System.Exception inner)
            : base(message, inner)
        {
            messageExplicit = !string.IsNullOrEmpty(message);
        }

        public ConditionException(string message, string subjectName)
            : base(message)
        {
            SubjectName = subjectName;
            messageExplicit = !string.IsNullOrEmpty(message);
        }

        public ConditionException(string message, string subjectName, System.Exception inner)
            : base(message, inner)
        {
            SubjectName = subjectName;
            messageExplicit = !string.IsNullOrEmpty(message);
        }


        //public ConditionException(ExceptionTypes exceptionType)
        //{
        //    if(exceptionType == ExceptionTypes.None)
        //        throw new ArgumentException("Exceptiontype can not be None", "exceptionType");
        //    ExceptionType = exceptionType;
        //}

        //public ConditionException(ExceptionTypes exceptionType, System.Exception inner)
        //    : base(null, inner)
        //{
        //    if(exceptionType == ExceptionTypes.None)
        //        throw new ArgumentException("Exceptiontype can not be None", "exceptionType");
        //    ExceptionType = exceptionType;
        //}

        //public ConditionException(ExceptionTypes exceptionType, string subjectName)
        //{
        //    if(exceptionType == ExceptionTypes.None)
        //        throw new ArgumentException("Exceptiontype can not be None", "exceptionType");
        //    SubjectName = subjectName;
        //    ExceptionType = exceptionType;

        //}

        //public ConditionException(ExceptionTypes exceptionType, string subjectName, System.Exception inner)
        //    : base(null, inner)
        //{
        //    if(exceptionType == ExceptionTypes.None)
        //        throw new ArgumentException("Exceptiontype can not be None", "exceptionType");
        //    SubjectName = subjectName;
        //    ExceptionType = exceptionType;
        //}

        internal protected ConditionException(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args)
        {
            ExceptionType = exceptionType;
            SubjectName = subjectName;
            SubjectValue = subjectValue;
            ResourceKey = resourceKey;
            Args = args;
        }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        //protected ConditionException(System.Runtime.Serialization.SerializationInfo info,
        //    System.Runtime.Serialization.StreamingContext context) { }


        public override string Message
        {
            get
            {
                return messageExplicit
                    ? base.Message + GetSubjectName()
                    : ExceptionType != ExceptionTypes.None
                        ? ExceptionMessageProvider.Current.GetExceptionMessage(ExceptionType, SubjectName, SubjectValue, ResourceKey, Args)
                        : base.Message;
            }
        }

        private string GetSubjectName()
        {
            return SubjectName != null ? Environment.NewLine + "Parameter name: " + SubjectName : null;
        }

        public string SubjectName
        {
            get;
            private set;
        }

        public object SubjectValue
        {
            get;
            private set;
        }

        private string ResourceKey;
        private object[] Args;

        public ExceptionTypes ExceptionType
        {
            get;
            private set;
        }
    }







}
