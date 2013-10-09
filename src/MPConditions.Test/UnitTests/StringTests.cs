using Xunit;

namespace MPConditions.Test.UnitTests
{
    public class StringTests
    {
        [Fact]
        public void IsNotNull()
        {
            {
                string foo = "Mike was here";

                foo.Condition().IsNotNull().Success();
            }
            {
                string foo = null;

                foo.Condition().IsNotNull().Fail(ExceptionTypes.Null);
            }
        }

        [Fact]
        public void IsNull()
        {
            {
                string foo = "Mike was here";

                foo.Condition().IsNull().Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = null;

                foo.Condition().IsNull().Success();
            }
        }

        [Fact]
        public void IsOfType()
        {
            {
                string foo = "Mike was here";

                foo.Condition().IsOfType<string>().Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().IsOfType<int>().Fail(ExceptionTypes.WrongType);
            }
        }

        [Fact(Skip = "How to test for strings")]
        public void IsAssignableTo()
        {

        }

        [Fact]
        public void Match()
        {

        }


        [Fact]
        public void StartsWith()
        {
            {
                string foo = "Mike was here";

                foo.Condition().StartsWith("Mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsWith("Miko").Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = null;

                foo.Condition().StartsWith("Miko").Fail(ExceptionTypes.Null);
            }
            {
                string foo = "";

                foo.Condition().StartsWith("Miko").Fail(ExceptionTypes.OutOfRange);
            }
        }

        [Fact(Skip = "Inconclusive")]
        public void AsNumber()
        {
        }

        [Fact(Skip = "Inconclusive")]
        public void AsNullableNumber()
        {
        }

        [Fact]
        public void Is()
        {
            {
                string foo = "Mike was here";

                foo.Condition().Is("Mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().Is("mike was here").Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = "Mike was here";

                foo.Condition().Is("Mike was hero").Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = null;

                foo.Condition().Is("Miko").Fail(ExceptionTypes.Null);
            }
            {
                string foo = "";

                foo.Condition().Is("Miko").Fail(ExceptionTypes.OutOfRange);
            }
        }

        [Fact(Skip = "Inconclusive")]
        public void IsOneOf()
        {

        }

        //[Fact]
        //public void IsOneOf(IEnumerable<string> validValues)
        //{

        //}

        [Fact]
        public void IsEquivalentTo()
        {
            {
                string foo = "Mike was here";

                foo.Condition().IsEquivalentTo("Mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().IsEquivalentTo("mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().IsEquivalentTo("Mike was hero").Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = null;

                foo.Condition().IsEquivalentTo("Miko").Fail(ExceptionTypes.Null);
            }
            {
                string foo = "";

                foo.Condition().IsEquivalentTo("Miko").Fail(ExceptionTypes.OutOfRange);
            }

        }

        [Fact(Skip = "Inconclusive")]
        public void IsNot()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void Matches()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void MatchesNot()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void MatchesEquivalentOf()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void MatchesNotEquivalentOf()
        {

        }



        [Fact(Skip = "Inconclusive")]
        public void StartsNotWith()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void StartsWithEquivalent()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void StartsNotWithEquivalentOf()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void EndsWith()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void EndsNotWith()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void EndsWithEquivalent()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void EndsNotWithEquivalentOf()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void Contains()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void ContainsEquivalentOf()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void ContainsNot()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void ContainsNotEquivalentOf()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void IsEmpty()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void IsNotEmpty()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void HasLength()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void IsNotNullOrEmpty()
        {

        }

        [Fact(Skip = "Inconclusive")]
        public void IsNullOrEmpty()
        {

        }

        [Fact]
        public void IsNotBlank()
        {
            {
                string foo = null;

                foo.Condition().IsNotBlank().Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = "";

                foo.Condition().IsNotBlank().Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = " ";

                foo.Condition().IsNotBlank().Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = "Whatever";

                foo.Condition().IsNotBlank().Success();
            }
        }

        [Fact]
        public void IsBlank()
        {
            {
                string foo = null;

                foo.Condition().IsBlank().Success();
            }
            {
                string foo = "";

                foo.Condition().IsBlank().Success();
            }
            {
                string foo = " ";

                foo.Condition().IsBlank().Success();
            }
            {
                string foo = "Whatever";

                foo.Condition().IsBlank().Fail(ExceptionTypes.OutOfRange);
            }
        }
    }
}
