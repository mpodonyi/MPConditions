using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;
using MPConditions.Primitives;

namespace MPConditions.DefaultExtensions
{
    public static class StringExtensions
    {
        public static StringCondition StartsWith(this StringCondition condition, string predicate)
        {
            ICondition<string> cond = condition;
            cond.Push(() =>
            {
                if(!cond.Subject.StartsWith(predicate))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, "Starts not with '{0}'", predicate);
                }

                return null;
            });

            return condition;
        }

        public static NumberCondition<T> AsNumber<T>(this StringCondition condition) where T : struct, IComparable<T>
        {
            ICondition<string> cond = condition;
            cond.Push(() =>
            {
                try
                {
                    Convert.ChangeType(cond.Subject, typeof(T), null);
                }
                catch
                {
                    return new ValidationInfo(ExceptionTypes.WrongType, "issue")
                    {
                        FailFast = true// string.Format("Type can not be translates to '{0}'", predicate),
                    };
                }

                return null;
            });

            T value = default(T);

            try
            {
                value = (T)Convert.ChangeType(cond.Subject, typeof(T), null);
            }
            catch
            {
                //in case of exception just give default value to next condition because when Throw method executes it will break anyway in the enqued test
            }

            var retVal = new NumberCondition<T>(value, condition.SubjectName, condition.Subject);
            retVal.MergeIn(condition);
            return retVal;
        }

        public static NullableNumberCondition<T> AsNullableNumber<T>(this StringCondition condition, bool emptyAsNull = true) where T : struct, IComparable<T>
        {
            ICondition<string> cond = condition ;
            cond.Push(() =>
            {
                try
                {
                    if(cond.Subject == null)
                        return null;

                    if(cond.Subject == string.Empty)
                    {
                        return emptyAsNull
                            ? null
                            : new ValidationInfo(ExceptionTypes.WrongType, "issue")
                                            {
                                                FailFast = true// string.Format("Type can not be translates to '{0}'", predicate),
                                            };
                    }

                    Convert.ChangeType(cond.Subject, typeof(T), null);
                }
                catch
                {
                    return new ValidationInfo(ExceptionTypes.WrongType, "issue")
                    {
                        FailFast = true// string.Format("Type can not be translates to '{0}'", predicate),
                    };
                }

                return null;
            });

            T? value = default(T?);

            try
            {
                value = string.IsNullOrEmpty(cond.Subject)
                    ? (T?)null
                    : (T)Convert.ChangeType(cond.Subject, typeof(T), null);
            }
            catch
            {
            }

            var retVal = new NullableNumberCondition<T>(value, condition.SubjectName, condition.Subject);
            retVal.MergeIn(condition);
            return retVal;
        }



        /// <summary>
        /// Validates that Subject under test is not null.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public static StringCondition NotNull(this StringCondition condition)
        {
            ICondition<string> cond = condition;
            cond.Push(() =>
            {
                if(cond.Subject == null)
                {
                    return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
                }

                return null;
            });

            return condition;
        }


    }
}
