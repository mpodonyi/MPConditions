using MPConditions.Primitives;

namespace MPConditions
{
    public static class StringConditionsExtensions
    {
        public static StringCondition Condition(this string value, string name = null)
        {
            return new StringCondition(value, name);
        }
    }
}
