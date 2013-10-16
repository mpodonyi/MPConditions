using System;
using System.Collections.Generic;
using System.Linq;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public abstract class NumberConditionBase<TSubject, TOriginalSubject, TCondition> : ConditionBase<TSubject?, TOriginalSubject>
        where TSubject : struct, IComparable<TSubject>
        where TCondition : NumberConditionBase<TSubject, TOriginalSubject, TCondition>
    {

        //internal NumberCondition(T subjectValue, string subjectName)
        //    : base(subjectValue, subjectValue, subjectName)
        //{
        //}

        //internal NumberCondition(T subjectValue, object originalValue, string subjectName)
        //    : base(subjectValue, originalValue, subjectName)
        //{
        //}

        protected NumberConditionBase(TSubject? subjectValue, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
        }

        protected NumberConditionBase(TSubject? subjectValue, TOriginalSubject originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

        public TCondition Or
        {
            get
            {
                this.Push(() => ValidationInfo.Or);
                return (TCondition)this;
            }
        }

        //public TCondition When<X, V>(ConditionBase<X, V> subcon) 
        //{
        //    this.Push(() =>
        //    {
        //        //var result = whenFunc();
        //        var res2 = subcon.GetResult();
        //        if(res2.ExceptionType == ExceptionTypes.None)
        //            return null;

        //        return new ValidationInfo(ExceptionTypes.OutOfRange);
        //    });

        //    return (TCondition)this;
        //}


        //public TCondition Between(TSubject start, TSubject end)
        //{
        //    this.Push(() =>
        //    {
        //        if(!this.SubjectValue.HasValue)
        //            return new ValidationInfo(ExceptionTypes.Null);

        //        //var comparer = new UniversalNumberComparer();

        //        if(!((this.SubjectValue.Value.CompareTo(start) > 0) && (this.SubjectValue.Value.CompareTo(end) < 0)))
        //        {
        //            return new ValidationInfo(ExceptionTypes.OutOfRange, start, end);
        //        }

        //        return null;
        //    });

        //    return (TCondition)this;
        //}


        #region AssertsImports

        public TCondition Is(TSubject expected)
        {
            this.Push(() =>
            {
                //MP: is this here necessary or is this covered by ReferenceEqual
                //if(!this.SubjectValue.HasValue)
                //    return new ValidationInfo(ExceptionTypes.Null);


                if(object.ReferenceEquals(SubjectValue, expected) || !object.ReferenceEquals(SubjectValue, null) && SubjectValue.Value.CompareTo(expected) == 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
            });

            return (TCondition)this;
        }

        public TCondition Is(TSubject? expected)
        {
            this.Push(() =>
            {
                if(object.ReferenceEquals(SubjectValue, expected)
                   // || object.ReferenceEquals(SubjectValue, null) && object.ReferenceEquals(expected, null)
                    || !object.ReferenceEquals(SubjectValue, null) && !object.ReferenceEquals(expected, null) && SubjectValue.Value.CompareTo(expected.Value) == 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange, expected);
            });

            return (TCondition)this;
        }

        public TCondition IsNot(TSubject unexpected)
        {
            this.Push(() =>
            {
                //MP: is this here necessary or is this covered by ReferenceEqual
                //if(!this.SubjectValue.HasValue)
                //    return new ValidationInfo(ExceptionTypes.Null);

                if(object.ReferenceEquals(SubjectValue, unexpected) || !object.ReferenceEquals(SubjectValue, null) && SubjectValue.Value.CompareTo(unexpected) == 0)
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return (TCondition)this;
        }

        public TCondition IsNot(TSubject? unexpected)
        {
            this.Push(() =>
            {
                if(object.ReferenceEquals(SubjectValue, unexpected)
                    //|| object.ReferenceEquals(SubjectValue, null) && object.ReferenceEquals(unexpected, null)
                    || !object.ReferenceEquals(SubjectValue, null) && !object.ReferenceEquals(unexpected, null) && SubjectValue.Value.CompareTo(unexpected.Value) == 0)
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, unexpected);
                }

                return null;
            });

            return (TCondition)this;
        }

        public TCondition IsPositive()
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(default(TSubject)) > 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsNegative()
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(default(TSubject)) < 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsLessThan(TSubject expected)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(expected) < 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsLessOrEqualTo(TSubject expected)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(expected) <= 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsGreaterThan(TSubject expected)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(expected) > 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsGreaterOrEqualTo(TSubject expected)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(expected) >= 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsInRange(TSubject minimumValue, TSubject maximumValue)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                if(this.SubjectValue.Value.CompareTo(minimumValue) >= 0 && this.SubjectValue.Value.CompareTo(maximumValue) <= 0)
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }

        public TCondition IsOneOf(params TSubject[] validValues)
        {
            return this.IsOneOf((IEnumerable<TSubject>)validValues);
        }

        public TCondition IsOneOf(IEnumerable<TSubject> validValues)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue && !object.ReferenceEquals(validValues,null))
                    return new ValidationInfo(ExceptionTypes.Null);

                if(Enumerable.Contains<TSubject>(validValues, this.SubjectValue.Value))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange, validValues);
            });

            return (TCondition)this;
        }



        #endregion


    }
}
