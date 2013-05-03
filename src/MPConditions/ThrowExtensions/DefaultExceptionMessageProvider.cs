using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public class DefaultExceptionMessageProvider : IExceptionMessageProvider
    {

        #region IExceptionMessageProvider Members

        public string GetExceptionMessage(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args)
        {
            resourceKey = resourceKey ?? GetExceptionTypeResourceKey(exceptionType);

            return string.Format(GetRessourceMessage(resourceKey), subjectName, subjectValue, args);
        }

        #endregion

        private string GetExceptionTypeResourceKey(ExceptionTypes exceptionType)
        {
            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                    return "Def_OutOfRange";
                case ExceptionTypes.Null:
                    return "Def_Null";
                case ExceptionTypes.StartsWith:
                    return "Def_StartsWith";
                case ExceptionTypes.WrongType:
                    return "Def_WrongType";
                default:
                    return null;
            }
        }

        private string GetRessourceMessage(string resourceKey)
        {
            return ResourceManager.GetString(resourceKey);
        }

        private static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if(object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MPConditions.Resource", typeof(DefaultExceptionMessageProvider).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        private static global::System.Resources.ResourceManager resourceMan;
    }
}
