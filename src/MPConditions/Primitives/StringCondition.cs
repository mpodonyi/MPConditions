using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            this.Push(() =>
            {
                if(string.Equals(this.SubjectValue, expected, StringComparison.CurrentCulture))
                    return null;

                return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
            });

            return this;
        }

        public StringCondition IsOneOf(params string[] validValues)
        {
            return this.IsOneOf((IEnumerable<string>)validValues);
        }

        public StringCondition IsOneOf(IEnumerable<string> validValues)
        {
            this.Push(() =>
            {
                if(Enumerable.Contains<string>(validValues, this.SubjectValue))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange, validValues);
            });

            return this;
        }

        public StringCondition IsEquivalentTo(string expected)
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

                if(!this.SubjectValue.Equals(expected, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
                }

                return null;
            });

            return this;
        }

        public StringCondition IsNot(string unexpected)
        {

            this.Push(() =>
            {
                if(string.Equals(this.SubjectValue, unexpected, StringComparison.CurrentCulture))
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);

                return null;
            });

            return this;
        }

        private static bool Match(string subject, string pattern, RegexOptions regexOptions)
        {
            if(subject == null && pattern == null)
                return true;

            if(subject == null || pattern == null)
                return false;

            string regex = "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";

            return Regex.IsMatch(subject, regex, regexOptions | RegexOptions.Singleline);
        }

        public StringCondition Matches(string wildcardPattern)
        {
            this.Push(() =>
            {
                if(Match(this.SubjectValue, wildcardPattern, RegexOptions.None))
                    return null;

                return new ValidationInfo(ExceptionTypes.OutOfRange, wildcardPattern);
            });

            return this;
        }

        public StringCondition MatchesNot(string wildcardPattern)
        {
            this.Push(() =>
            {
                if(!Match(this.SubjectValue, wildcardPattern, RegexOptions.None))
                    return null;

                return new ValidationInfo(ExceptionTypes.OutOfRange, wildcardPattern);
            });

            return this;
        }

        public StringCondition MatchesEquivalentOf(string wildcardPattern)
        {
            this.Push(() =>
            {
                if(Match(this.SubjectValue, wildcardPattern, RegexOptions.IgnoreCase))
                    return null;

                return new ValidationInfo(ExceptionTypes.OutOfRange, wildcardPattern);
            });

            return this;
        }

        public StringCondition MatchesNotEquivalentOf(string wildcardPattern)
        {
            this.Push(() =>
            {
                if(!Match(this.SubjectValue, wildcardPattern, RegexOptions.IgnoreCase))
                    return null;

                return new ValidationInfo(ExceptionTypes.OutOfRange, wildcardPattern);
            });

            return this;
        }

        public StringCondition StartsNotWith(string unexpected)
        {
            this.Push(() =>
            {
                if(unexpected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(unexpected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(this.SubjectValue.StartsWith(unexpected))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return this;
        }

        public StringCondition StartsWithEquivalent(string expected)
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

                if(!this.SubjectValue.StartsWith(expected, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
                }

                return null;
            });

            return this;
        }

        public StringCondition StartsNotWithEquivalentOf(string unexpected)
        {
            this.Push(() =>
            {
                if(unexpected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(unexpected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(this.SubjectValue.StartsWith(unexpected, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return this;
        }

        public StringCondition EndsWith(string expected)
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

                if(!this.SubjectValue.EndsWith(expected))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
                }

                return null;
            });

            return this;
        }


        public StringCondition EndsNotWith(string unexpected)
        {
            this.Push(() =>
            {
                if(unexpected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(unexpected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(this.SubjectValue.EndsWith(unexpected))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return this;
        }

        public StringCondition EndsWithEquivalent(string expected)
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

                if(!this.SubjectValue.EndsWith(expected, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
                }

                return null;
            });

            return this;
        }

        public StringCondition EndsNotWithEquivalentOf(string unexpected)
        {
            this.Push(() =>
            {
                if(unexpected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(unexpected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(this.SubjectValue.EndsWith(unexpected, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return this;
        }

        public StringCondition Contains(string expected)
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

                if(!this.SubjectValue.Contains(expected))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
                }

                return null;
            });

            return this;
        }

        public StringCondition ContainsEquivalentOf(string expected)
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

                if(this.SubjectValue.IndexOf(expected, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
            });

            return this;
        }

        public StringCondition ContainsNot(string unexpected)
        {
            this.Push(() =>
            {
                if(unexpected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(unexpected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(this.SubjectValue.Contains(unexpected))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return this;
        }

        public StringCondition ContainsNotEquivalentOf(string unexpected)
        {
            this.Push(() =>
            {
                if(unexpected == null)
                    throw new NullReferenceException("Cannot compare start of string with <null>.");
                if(unexpected.Length == 0)
                    throw new ArgumentException("Cannot compare start of string with empty string.");

                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(!(this.SubjectValue.IndexOf(unexpected, StringComparison.CurrentCultureIgnoreCase) >= 0))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
            });

            return this;
        }


        public StringCondition IsEmpty()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange);
                }

                if(this.SubjectValue.Length == 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return this;
        }

        public StringCondition IsNotEmpty()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(this.SubjectValue.Length == 0)
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange);
                }

                return null;
            });

            return this;
        }

        public StringCondition HasLength(int expected)
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange);
                }

                if(this.SubjectValue.Length == expected)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return this;
        }

        public StringCondition IsNotNullOrEmpty()
        {
            this.Push(() =>
            {
                if(!string.IsNullOrEmpty(this.SubjectValue))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return this;
        }

        public StringCondition IsNullOrEmpty()
        {
            this.Push(() =>
            {
                if(string.IsNullOrEmpty(this.SubjectValue))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return this;
        }

        public StringCondition IsNotNullOrWhiteSpace()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange);
                }

                if(string.IsNullOrEmpty(this.SubjectValue.Trim()))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange);
                }

                return null;
            });

            return this;
        }

        public StringCondition IsNullOrWhiteSpace()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return null;
                }

                if(string.IsNullOrEmpty(this.SubjectValue.Trim()))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return this;
        }
        #endregion



    }
}
