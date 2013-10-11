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

        [Fact(Skip = "How to test for strings (from ReferenceTypeCondition)")]
        public void IsAssignableTo()
        {

        }

        //[Fact(Skip = "How to test for strings (from ReferenceTypeCondition)")]
        //public void Matches()
        //{

        //}


        [Fact]
        public void StartsWith()
        {
            {
                string foo = "Mike was here";

                foo.Condition().StartsWith("Mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsWith("mike").Fail();
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
            {
                string foo = "foo";

                foo.Condition().StartsWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().StartsWith("").Throws();
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

        [Fact]
        public void Matches()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().Matches("*@*.Com").Success();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().Matches("*@*.com").Fail();
            }
            {
                string foo = null;

                foo.Condition().Matches(null).Success();
            }
            {
                string foo = null;

                foo.Condition().Matches("").Fail();
            }
            {
                string foo = "";

                foo.Condition().Matches(null).Fail();
            }
            {
                string foo = "";

                foo.Condition().Matches("").Success();
            }
            {
                string foo = "";

                foo.Condition().Matches("*").Success();
            }
        }

        [Fact]
        public void MatchesNot()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().MatchesNot("*@*.Com").Fail();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().MatchesNot("*@*.com").Success();
            }
            {
                string foo = null;

                foo.Condition().MatchesNot(null).Fail();
            }
            {
                string foo = null;

                foo.Condition().MatchesNot("").Success();
            }
            {
                string foo = "";

                foo.Condition().MatchesNot(null).Success();
            }
            {
                string foo = "";

                foo.Condition().MatchesNot("").Fail();
            }
            {
                string foo = "";

                foo.Condition().MatchesNot("*").Fail();
            }
        }

        [Fact]
        public void MatchesEquivalentOf()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().MatchesEquivalentOf("*@*.Com").Success();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().MatchesEquivalentOf("*@*.com").Success();
            }
            {
                string foo = null;

                foo.Condition().MatchesEquivalentOf(null).Success();
            }
            {
                string foo = null;

                foo.Condition().MatchesEquivalentOf("").Fail();
            }
            {
                string foo = "";

                foo.Condition().MatchesEquivalentOf(null).Fail();
            }
            {
                string foo = "";

                foo.Condition().MatchesEquivalentOf("").Success();
            }
            {
                string foo = "";

                foo.Condition().MatchesEquivalentOf("*").Success();
            }

        }

        [Fact]
        public void MatchesNotEquivalentOf()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().MatchesNotEquivalentOf("*@*.Com").Fail();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Condition().MatchesNotEquivalentOf("*@*.com").Fail();
            }
            {
                string foo = null;

                foo.Condition().MatchesNotEquivalentOf(null).Fail();
            }
            {
                string foo = null;

                foo.Condition().MatchesNotEquivalentOf("").Success();
            }
            {
                string foo = "";

                foo.Condition().MatchesNotEquivalentOf(null).Success();
            }
            {
                string foo = "";

                foo.Condition().MatchesNotEquivalentOf("").Fail();
            }
            {
                string foo = "";

                foo.Condition().MatchesNotEquivalentOf("*").Fail();
            }

        }



        [Fact]
        public void StartsNotWith()
        {
            {
                string foo = "Mike was here";

                foo.Condition().StartsNotWith("Mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsNotWith("mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsNotWith("Miko").Success();
            }
            {
                string foo = null;

                foo.Condition().StartsNotWith("Miko").Success();
            }
            {
                string foo = "";

                foo.Condition().StartsNotWith("Miko").Success();
            }
            {
                string foo = "foo";

                foo.Condition().StartsNotWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().StartsNotWith("").Throws();
            }
        }

        [Fact]
        public void StartsWithEquivalent()
        {
            {
                string foo = "Mike was here";

                foo.Condition().StartsWithEquivalent("Mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsWithEquivalent("mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsWithEquivalent("Miko").Fail();
            }
            {
                string foo = null;

                foo.Condition().StartsWithEquivalent("Miko").Fail();
            }
            {
                string foo = "";

                foo.Condition().StartsWithEquivalent("Miko").Fail();
            }
            {
                string foo = "foo";

                foo.Condition().StartsWithEquivalent(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().StartsWithEquivalent("").Throws();
            }


        }

        [Fact]
        public void StartsNotWithEquivalentOf()
        {
            {
                string foo = "Mike was here";

                foo.Condition().StartsNotWithEquivalentOf("Mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsNotWithEquivalentOf("mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().StartsNotWithEquivalentOf("Miko").Success();
            }
            {
                string foo = null;

                foo.Condition().StartsNotWithEquivalentOf("Miko").Success();
            }
            {
                string foo = "";

                foo.Condition().StartsNotWithEquivalentOf("Miko").Success();
            }
            {
                string foo = "foo";

                foo.Condition().StartsNotWithEquivalentOf(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().StartsNotWithEquivalentOf("").Throws();
            }

        }

        [Fact]
        public void EndsWith()
        {
            {
                string foo = "Mike was here";

                foo.Condition().EndsWith("here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsWith("Here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsWith("hero").Fail();
            }
            {
                string foo = null;

                foo.Condition().EndsWith("hero").Fail();
            }
            {
                string foo = "";

                foo.Condition().EndsWith("hero").Fail();
            }
            {
                string foo = "foo";

                foo.Condition().EndsWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().EndsWith("").Throws();
            }
        }

        [Fact]
        public void EndsNotWith()
        {
            {
                string foo = "Mike was here";

                foo.Condition().EndsNotWith("here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsNotWith("Here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsNotWith("hero").Success();
            }
            {
                string foo = null;

                foo.Condition().EndsNotWith("hero").Success();
            }
            {
                string foo = "";

                foo.Condition().EndsNotWith("hero").Success();
            }
            {
                string foo = "foo";

                foo.Condition().EndsNotWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().EndsNotWith("").Throws();
            }

        }

        [Fact]
        public void EndsWithEquivalent()
        {
            {
                string foo = "Mike was here";

                foo.Condition().EndsWithEquivalent("here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsWithEquivalent("Here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsWithEquivalent("hero").Fail();
            }
            {
                string foo = null;

                foo.Condition().EndsWithEquivalent("hero").Fail();
            }
            {
                string foo = "";

                foo.Condition().EndsWithEquivalent("hero").Fail();
            }
            {
                string foo = "foo";

                foo.Condition().EndsWithEquivalent(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().EndsWithEquivalent("").Throws();
            }

        }

        [Fact]
        public void EndsNotWithEquivalentOf()
        {
            {
                string foo = "Mike was here";

                foo.Condition().EndsNotWithEquivalentOf("here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsNotWithEquivalentOf("Here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Condition().EndsNotWithEquivalentOf("hero").Success();
            }
            {
                string foo = null;

                foo.Condition().EndsNotWithEquivalentOf("hero").Success();
            }
            {
                string foo = "";

                foo.Condition().EndsNotWithEquivalentOf("hero").Success();
            }
            {
                string foo = "foo";

                foo.Condition().EndsNotWithEquivalentOf(null).Throws();
            }
            {
                string foo = "foo";

                foo.Condition().EndsNotWithEquivalentOf("").Throws();
            }

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

        [Fact]
        public void IsEmpty()
        {
            {
                string foo = null;

                foo.Condition().IsEmpty().Fail();
            }
            {
                string foo = "";

                foo.Condition().IsEmpty().Success();
            }
            {
                string foo = " ";

                foo.Condition().IsEmpty().Fail();
            }
            {
                string foo = "Whatever";

                foo.Condition().IsEmpty().Fail();
            }
        }

        [Fact]
        public void IsNotEmpty()
        {
            {
                string foo = null;

                foo.Condition().IsNotEmpty().Success();
            }
            {
                string foo = "";

                foo.Condition().IsNotEmpty().Fail();
            }
            {
                string foo = " ";

                foo.Condition().IsNotEmpty().Success();
            }
            {
                string foo = "Whatever";

                foo.Condition().IsNotEmpty().Success();
            }
        }

        [Fact]
        public void HasLength()
        {
            {
                string foo = null;

                foo.Condition().HasLength(8).Fail();
            }
            {
                string foo = "";

                foo.Condition().HasLength(8).Fail();
            }
            {
                string foo = " ";

                foo.Condition().HasLength(8).Fail();
            }
            {
                string foo = "Whatever";

                foo.Condition().HasLength(8).Success();
            }
            {
                string foo = null;

                foo.Condition().HasLength(0).Fail();
            }
            {
                string foo = "";

                foo.Condition().HasLength(0).Success();
            }
            {
                string foo = "";

                foo.Condition().HasLength(-5).Fail();
            }
        }

        [Fact]
        public void IsNotNullOrEmpty()
        {
            {
                string foo = null;

                foo.Condition().IsNotNullOrEmpty().Fail();
            }
            {
                string foo = "";

                foo.Condition().IsNotNullOrEmpty().Fail();
            }
            {
                string foo = " ";

                foo.Condition().IsNotNullOrEmpty().Success();
            }
            {
                string foo = "Whatever";

                foo.Condition().IsNotNullOrEmpty().Success();
            }

        }

        [Fact]
        public void IsNullOrEmpty()
        {
            {
                string foo = null;

                foo.Condition().IsNullOrEmpty().Success();
            }
            {
                string foo = "";

                foo.Condition().IsNullOrEmpty().Success();
            }
            {
                string foo = " ";

                foo.Condition().IsNullOrEmpty().Fail();
            }
            {
                string foo = "Whatever";

                foo.Condition().IsNullOrEmpty().Fail();
            }

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
