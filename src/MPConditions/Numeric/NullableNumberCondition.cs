using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T, TPassthrough> : NumberCondition<T, TPassthrough>
        , INullableNumberCondition<T, TPassthrough>
        where T : struct, IComparable<T>
    {
        public NullableNumberCondition(T? value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {

        }


        //#region INullableNumberCondition<T> Members

        //public T? Subject
        //{
        //    get { return this._Value.Value; }
        //}

        //public void Push(Func<ExecutionContext> action)
        //{
        //    ec.Enqueue(action);
        //}

        //#endregion

        //#region INumberCondition<T?,TPassthrough> Members

        //public new T? Subject
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //#endregion

        #region INumberCondition<T?,TPassthrough> Members

        public new T? Subject
        {
            get { return this._Value; }
        }

        //MP: how does this look like in the fluent interface

        public new INullableNumberCondition<T, TPassthrough> Or
        {
            get { return base.Or as INullableNumberCondition<T,TPassthrough>; }
        }


        INumberCondition<T?, TPassthrough> INumberCondition<T?, TPassthrough>.Or
        {
            get { return base.Or as INumberCondition<T?,TPassthrough>; }
        }

        #endregion
    }

    




   


}
