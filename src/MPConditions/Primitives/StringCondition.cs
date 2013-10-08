using System;
using System.Collections.Generic;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public class StringCondition : ReferenceTypeCondition<string, string, StringCondition>
    {
        internal StringCondition(string subjectValue, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
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



        ///// <summary>
        ///// Validates that Subject under test is not null.
        ///// </summary>
        ///// <param name="condition">The condition.</param>
        ///// <returns></returns>
        //public StringCondition NotNull()
        //{
        //    this.Push(() =>
        //    {
        //        if(this.SubjectValue == null)
        //        {
        //            return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
        //        }

        //        return null;
        //    });

        //    return this;
        //}


        #region ImportedFromFluidValidation
        public StringCondition Be(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition BeOneOf(params string[] validValues)
        {
            return this;
        }

        public StringCondition BeOneOf(IEnumerable<string> validValues, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition BeEquivalentTo(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotBe(string unexpected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition Match(string wildcardPattern, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotMatch(string wildcardPattern, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition MatchEquivalentOf(string wildcardPattern, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotMatchEquivalentOf(string wildcardPattern, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition StartWith(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotStartWith(string unexpected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition StartWithEquivalent(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotStartWithEquivalentOf(string unexpected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition EndWith(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }


        public StringCondition NotEndWith(string unexpected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition EndWithEquivalent(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotEndWithEquivalentOf(string unexpected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition Contain(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition ContainEquivalentOf(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotContain(string expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotContainEquivalentOf(string unexpected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }


        public StringCondition BeEmpty(string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotBeEmpty(string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition HaveLength(int expected, string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotBeNullOrEmpty(string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition BeNullOrEmpty(string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition NotBeBlank(string reason = "", params object[] reasonArgs)
        {
            return this;
        }

        public StringCondition BeBlank(string reason = "", params object[] reasonArgs)
        {
            return this;
        }
        #endregion



    }
}
