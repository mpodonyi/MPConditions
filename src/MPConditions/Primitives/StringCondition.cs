using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    public class StringCondition : ConditionBase<string,string, StringCondition>, IStringCondition
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

        public NumberCondition<T,string> AsNumber<T>() where T : struct, IComparable<T>
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

            return new NumberCondition<T, string>(value, _OriginalValue, _ArgumentName).MerginQueue(this.ec);
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

        public void Push(Func<ExecutionContext> action)
        {
            ec.Enqueue(action);
        }

        #endregion
    }
}
