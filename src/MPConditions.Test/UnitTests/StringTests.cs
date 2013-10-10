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

                foo.Condition().IsNotNull().Fail();
            }
        }

        [Fact]
        public void IsNull()
        {
            {
                string foo = "Mike was here";

                foo.Condition().IsNull().Fail();
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

                foo.Condition().IsOfType<int>().Fail();
            }
        }

        [Fact(Skip = "How to test for strings")]
        public void IsAssignableTo()
        {

        }

        [Fact(Skip = "How to test for strings")]
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

                foo.Condition().StartsWith("Miko").Fail();
            }
            {
                string foo = null;

                foo.Condition().StartsWith("Miko").Fail();
            }
            {
                string foo = "";

                foo.Condition().StartsWith("Miko").Fail();
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

                foo.Condition().Is("mike was here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().Is("Mike was hero").Fail();
            }
            {
                string foo = null;

                foo.Condition().Is("Miko").Fail();
            }
            {
                string foo = "";

                foo.Condition().Is("Miko").Fail();
            }
            {
                string foo = "";

                foo.Condition().Is("").Success();
            }
            {
                string foo = "";

                foo.Condition().Is(null).Fail();
            }
            {
                string foo = null;

                foo.Condition().Is(null).Success();
            }
        }

        [Fact]
        public void IsOneOf()
        {
            {
                string foo = "Mike";

                foo.Condition().IsOneOf(null).Throws();
            }
            {
                string foo = "Mike";

                foo.Condition().IsOneOf("foo", "bar").Fail();
            }
            {
                string foo = "Mike";

                foo.Condition().IsOneOf("foo", "Mike", "bar").Success();
            }
            {
                string foo = "Mike";

                foo.Condition().IsOneOf("foo", "mike", "bar").Fail();
            }
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

                foo.Condition().IsEquivalentTo("Mike was hero").Fail();
            }
            {
                string foo = null;

                foo.Condition().IsEquivalentTo("Miko").Fail();
            }
            {
                string foo = "";

                foo.Condition().IsEquivalentTo("Miko").Fail();
            }

        }

        [Fact]
        public void IsNot()
        {
            {
                string foo = "Mike was here";

                foo.Condition().IsNot("Mike was here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().IsNot("mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().IsNot("Mike was hero").Success();
            }
            {
                string foo = null;

                foo.Condition().IsNot("Miko").Success();
            }
            {
                string foo = "";

                foo.Condition().IsNot("Miko").Success();
            }
            {
                string foo = "";

                foo.Condition().IsNot("").Fail();
            }
            {
                string foo = "";

                foo.Condition().IsNot(null).Success();
            }
            {
                string foo = null;

                foo.Condition().IsNot(null).Fail();
            }
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

                foo.Condition().IsNotBlank().Fail();
            }
            {
                string foo = "";

                foo.Condition().IsNotBlank().Fail();
            }
            {
                string foo = " ";

                foo.Condition().IsNotBlank().Fail();
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

                foo.Condition().IsBlank().Fail();
            }
        }
    }
}
