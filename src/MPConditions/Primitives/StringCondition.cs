using System;
using MPConditions.Common;

namespace MPConditions.Primitives
{
    public class StringCondition : ConditionBase<string, string>, IFluentInterface
    {
        internal StringCondition(string subjectValue, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
        }

        public StringCondition Or
        {
            get
            {
                this.Push(() => ValidationInfo.Or);
                return this;
            }
        }

        public StringCondition StartsWith(string predicate)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.StartsWith(predicate))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, predicate);
                }

                return null;
            });

            return this;
        }

        public NumberCondition<T, string> AsNumber<T>() where T : struct, IComparable<T>
        {
            this.Push(() =>
            {
                try
                {
                    Convert.ChangeType(this.SubjectValue, typeof(T), null);
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
                value = (T)Convert.ChangeType(this.SubjectValue, typeof(T), null);
            }
            catch
            {
                //in case of exception just give default value to next condition because when Throw method executes it will break anyway in the enqued test
            }

            var retVal = new NumberCondition<T, string>(value, this.SubjectValue, this.SubjectName);
            retVal.MergeIn(this);
            return retVal;
        }

        public NullableNumberCondition<T, string> AsNullableNumber<T>(bool emptyAsNull = true) where T : struct, IComparable<T>
        {
            this.Push(() =>
            {
                try
                {
                    if(this.SubjectValue == null)
                        return null;

                    if(this.SubjectValue == string.Empty)
                    {
                        return emptyAsNull
                            ? null
                            : new ValidationInfo(ExceptionTypes.WrongType, typeof(T))
                            {
                                FailFast = true// string.Format("Type can not be translates to '{0}'", predicate),
                            };
                    }

                    Convert.ChangeType(this.SubjectValue, typeof(T), null);
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
                value = string.IsNullOrEmpty(this.SubjectValue)
                    ? (T?)null
                    : (T)Convert.ChangeType(this.SubjectValue, typeof(T), null);
            }
            catch
            {
            }

            var retVal = new NullableNumberCondition<T, string>(value, this.SubjectValue, this.SubjectName);
            retVal.MergeIn(this);
            return retVal;
        }



        /// <summary>
        /// Validates that Subject under test is not null.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public StringCondition NotNull()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
                }

                return null;
            });

            return this;
        }




    }
}
