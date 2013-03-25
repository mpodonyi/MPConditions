using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    internal class StringCondition : ConditionBase<string,string>, IStringCondition
    {

        public StringCondition(string value, string name)
            : base(value,value, name)
        {
        }

        //public StringCondition ConvertibleTo<T>()
        //{
        //    ec.Enqueue(() =>
        //   {
        //       try
        //       {
        //           Convert.ChangeType(_Value, typeof(T), null);
        //       }
        //       catch
        //       {
        //           return new ExecutionContext(ExecutionTypes.WrongType, "issue");// string.Format("Type can not be translates to '{0}'", predicate),
        //       }

        //       return ExecutionContext.Empty;
        //   });

        //    return this;
        //}

        

        //public NullableNumberCondition<T> AsNullableNumber<T>() where T : struct, IComparable<T>
        //{
        //    //ec.Enqueue(() =>
        //    //{
        //    //    try
        //    //    {
        //    //        Convert.ChangeType(_Value, typeof(T), null);

        //    //    }
        //    //    catch
        //    //    {
        //    //        return new ExecutionContext
        //    //        {
        //    //            ExecutionType = ExecutionTypes.WrongType,
        //    //            Message = "issue",// string.Format("Type can not be translates to '{0}'", predicate),
        //    //        };
        //    //    }

        //    //    return ExecutionContext.Empty;
        //    //});

        //    T value = (T)Convert.ChangeType(_Value, typeof(T), null);
        //    return new NullableNumberCondition<T>(value, _ArgumentName);
        //}

       
        



       



        #region IStringCondition Members

        public string Subject
        {
            get { return this._Value; }
        }


        public new IStringCondition Or
        {
            get { return base.Or as IStringCondition; }
        }

        #endregion
    }
}
