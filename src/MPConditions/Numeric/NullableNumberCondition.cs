﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    internal class NullableNumberCondition<T, TPassthrough> : NumberCondition<T, TPassthrough>
        , INullableNumberCondition<T, TPassthrough>
        where T : struct, IComparable<T>
    {
        public NullableNumberCondition(T? value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {
        }

        public NullableNumberCondition(T? value, ConditionBase<TPassthrough, TPassthrough> mother)
            : base(value, mother)
        {
        }

        #region INumberCondition<T?,TPassthrough> Members

        public new T? Subject
        {
            get { return this._Value; }
        }



        public new INullableNumberCondition<T, TPassthrough> Or
        {
            get { return base.Or as INullableNumberCondition<T, TPassthrough>; }
        }


        //INumberCondition<T?, TPassthrough> INumberCondition<T?, TPassthrough>.Or
        //{
        //    get { return base.Or as INumberCondition<T?,TPassthrough>; }
        //}

        #endregion
    }









}
