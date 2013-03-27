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
        public static IStringCondition StartsWith(this IStringCondition condition, string predicate)
        {
            condition.Push(() =>
            {
                if(!condition.Subject.StartsWith(predicate))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, "Starts not with '{0}'", predicate);
                }

                return null;
            });

            return condition;
        }

        public static INumberCondition<T, string> AsNumber<T>(this IStringCondition condition) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                try
                {
                    Convert.ChangeType(condition.Subject, typeof(T), null);

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
                value = (T)Convert.ChangeType(condition.Subject, typeof(T), null);
            }
            catch
            {
                //in case of exception just give default value to next condition because when Throw method executes it will break anyway in the enqued test
            }

            return new NumberCondition<T, string>(value, condition as StringCondition);
        }

        public static INullableNumberCondition<T, string> AsNullableNumber<T>(this IStringCondition condition, bool emptyAsNull = true) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                try
                {
                    if(condition.Subject == null)
                        return null;

                    if(condition.Subject == string.Empty)
                    {
                        return emptyAsNull
                            ? null
                            : new ValidationInfo(ExceptionTypes.WrongType, "issue")
                                            {
                                                FailFast = true// string.Format("Type can not be translates to '{0}'", predicate),
                                            };
                    }

                    Convert.ChangeType(condition.Subject, typeof(T), null);
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
                value = string.IsNullOrEmpty(condition.Subject)
                    ? (T?)null
                    : (T)Convert.ChangeType(condition.Subject, typeof(T), null);
            }
            catch
            {
            }

            return new NullableNumberCondition<T, string>(value, condition as StringCondition);
        }


    }
}
