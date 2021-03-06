﻿using System;
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

        public INumberCondition<T,string> AsNumber<T>() where T : struct, IComparable<T>
        {
            ec.Enqueue(() =>
            {
                try
                {
                    Convert.ChangeType(_Value, typeof(T), null);

                }
                catch
                {
                    return new ExecutionContext(ExceptionTypes.WrongType, "issue")
                    {
                        FailFast = true// string.Format("Type can not be translates to '{0}'", predicate),
                    };
                }

                return ExecutionContext.Empty;
            });

            T value = default(T);

            try
            {
                value = (T)Convert.ChangeType(_Value, typeof(T), null);
            }
            catch
            {
                //in case of exception just give default value to next condition because when Throw method executes it will break anyway in the enqued test
            }

            var retVal=new NumberCondition<T,string>(value, OriginalValue, _ArgumentName);
            retVal.MerginQueue(this.ec);

            return retVal;
        }

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
