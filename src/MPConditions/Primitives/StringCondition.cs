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

        public StringCondition StartsWith(string expected)
        {
            this.Push(() =>
            {
                if(expected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(expected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.Null, expected);
                }

                if(!this.SubjectValue.StartsWith(expected))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
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
        public StringCondition Is(string expected)
        {
            return this;
        }

        public StringCondition IsOneOf(params string[] validValues)
        {
            return this;
        }

        public StringCondition IsOneOf(IEnumerable<string> validValues)
        {
            return this;
        }

        public StringCondition IsEquivalentTo(string expected)
        {
            return this;
        }

        public StringCondition IsNot(string unexpected)
        {
            return this;
        }

        public StringCondition Match(string wildcardPattern)
        {
            return this;
        }

        public StringCondition MatchNot(string wildcardPattern)
        {
            return this;
        }

        public StringCondition MatchEquivalentOf(string wildcardPattern)
        {
            return this;
        }

        public StringCondition MatchNotEquivalentOf(string wildcardPattern)
        {
            return this;
        }

        public StringCondition StartWith(string expected)
        {
            return this;
        }

        public StringCondition StartNotWith(string unexpected)
        {
            return this;
        }

        public StringCondition StartWithEquivalent(string expected)
        {
            return this;
        }

        public StringCondition StartNotWithEquivalentOf(string unexpected)
        {
            return this;
        }

        public StringCondition EndWith(string expected)
        {
            return this;
        }


        public StringCondition EndNotWith(string unexpected)
        {
            return this;
        }

        public StringCondition EndWithEquivalent(string expected)
        {
            return this;
        }

        public StringCondition EndNotWithEquivalentOf(string unexpected)
        {
            return this;
        }

        public StringCondition Contain(string expected)
        {
            return this;
        }

        public StringCondition ContainEquivalentOf(string expected)
        {
            return this;
        }

        public StringCondition ContainNot(string expected)
        {
            return this;
        }

        public StringCondition ContainNotEquivalentOf(string unexpected)
        {
            return this;
        }


        public StringCondition IsEmpty()
        {
            return this;
        }

        public StringCondition IsNotEmpty()
        {
            return this;
        }

        public StringCondition HasLength(int expected)
        {
            return this;
        }

        public StringCondition IsNotNullOrEmpty()
        {
            return this;
        }

        public StringCondition IsNullOrEmpty()
        {
            return this;
        }

        public StringCondition IsNotBlank()
        {
            return this;
        }

        public StringCondition IsBlank()
        {
            return this;
        }
        #endregion



    }
}
