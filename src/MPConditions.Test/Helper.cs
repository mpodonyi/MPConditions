using System;
using FluentAssertions;
using MPConditions.Core;

namespace MPConditions.Test
{
    public static class Helper
    {
        public static void Success<TValue, TOriginal>(this ConditionBase<TValue, TOriginal> item)
        {
            item.GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        public static void Fail<TValue, TOriginal>(this ConditionBase<TValue, TOriginal> item)
        {
            item.GetResult().ExceptionType.Should().NotBe(ExceptionTypes.None);
        }

        public static void Throws<TValue, TOriginal>(this ConditionBase<TValue, TOriginal> item)
        {
            Action act = () => item.GetResult();

            act.ShouldThrow<Exception>();
        }
    }
}
