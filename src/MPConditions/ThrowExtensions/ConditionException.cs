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
        public ConditionException() : base() { }
        public ConditionException(string message) : base(message) { }
        public ConditionException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        //protected ConditionException(System.Runtime.Serialization.SerializationInfo info,
        //    System.Runtime.Serialization.StreamingContext context) { }




        internal ConditionException(string paramName, string message)
        {
            ParamName = paramName;
      //      Message = message;
           // ExecutionTypes = executionTypes;
        }

        public string ParamName
        {
            get;
            private set;
        }
    }



    
   


}
