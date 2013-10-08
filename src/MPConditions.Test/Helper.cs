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

        public static void Fail<TValue, TOriginal>(this ConditionBase<TValue, TOriginal> item, ExceptionTypes exceptionType)
        {
            item.GetResult().ExceptionType.Should().Be(exceptionType);
        }
    }
}
