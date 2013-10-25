using Xunit;

namespace MPConditions.Test.UnitTests
{
    public class StringConditionTests
    {
        [Fact]
        public void IsNotNull()
        {
            {
                string foo = "Mike was here";

                foo.Cond().IsNotNull().Success();
            }
            {
                string foo = null;

                foo.Cond().IsNotNull().Fail();
            }
        }

        [Fact]
        public void IsNull()
        {
            {
                string foo = "Mike was here";

                foo.Cond().IsNull().Fail();
            }
            {
                string foo = null;

                foo.Cond().IsNull().Success();
            }
        }

        [Fact]
        public void IsOfType()
        {
            {
                string foo = "Mike was here";

                foo.Cond().IsOfType<string>().Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().IsOfType<int>().Fail();
            }
        }

        [Fact(Skip = "How to test for strings (from ReferenceTypeCondition)")]
        public void IsAssignableTo()
        {
            return;

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

                foo.Cond().StartsWith("Mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsWith("mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsWith("Miko").Fail();
            }
            {
                string foo = null;

                foo.Cond().StartsWith("Miko").Fail();
            }
            {
                string foo = "";

                foo.Cond().StartsWith("Miko").Fail();
            }
            {
                string foo = "foo";

                foo.Cond().StartsWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().StartsWith("").Throws();
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

                foo.Cond().Is("Mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().Is("mike was here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().Is("Mike was hero").Fail();
            }
            {
                string foo = null;

                foo.Cond().Is("Miko").Fail();
            }
            {
                string foo = "";

                foo.Cond().Is("Miko").Fail();
            }
            {
                string foo = "";

                foo.Cond().Is("").Success();
            }
            {
                string foo = "";

                foo.Cond().Is(null).Fail();
            }
            {
                string foo = null;

                foo.Cond().Is(null).Success();
            }
        }

        [Fact]
        public void IsOneOf()
        {
            {
                string foo = null;

                foo.Cond().IsOneOf("foo", "bar").Fail();
            }
            {
                string foo = "Mike";

                foo.Cond().IsOneOf(null).Throws();
            }
            {
                string foo = "Mike";

                foo.Cond().IsOneOf("foo", "bar").Fail();
            }
            {
                string foo = "Mike";

                foo.Cond().IsOneOf("foo", "Mike", "bar").Success();
            }
            {
                string foo = "Mike";

                foo.Cond().IsOneOf("foo", "mike", "bar").Fail();
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

                foo.Cond().IsEquivalentTo("Mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().IsEquivalentTo("mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().IsEquivalentTo("Mike was hero").Fail();
            }
            {
                string foo = null;

                foo.Cond().IsEquivalentTo("Miko").Fail();
            }
            {
                string foo = "";

                foo.Cond().IsEquivalentTo("Miko").Fail();
            }

        }

        [Fact]
        public void IsNot()
        {
            {
                string foo = "Mike was here";

                foo.Cond().IsNot("Mike was here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().IsNot("mike was here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().IsNot("Mike was hero").Success();
            }
            {
                string foo = null;

                foo.Cond().IsNot("Miko").Success();
            }
            {
                string foo = "";

                foo.Cond().IsNot("Miko").Success();
            }
            {
                string foo = "";

                foo.Cond().IsNot("").Fail();
            }
            {
                string foo = "";

                foo.Cond().IsNot(null).Success();
            }
            {
                string foo = null;

                foo.Cond().IsNot(null).Fail();
            }
        }

        [Fact]
        public void Matches()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().Matches("*@*.Com").Success();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().Matches("*@*.com").Fail();
            }
            {
                string foo = null;

                foo.Cond().Matches(null).Success();
            }
            {
                string foo = null;

                foo.Cond().Matches("").Fail();
            }
            {
                string foo = "";

                foo.Cond().Matches(null).Fail();
            }
            {
                string foo = "";

                foo.Cond().Matches("").Success();
            }
            {
                string foo = "";

                foo.Cond().Matches("*").Success();
            }
        }

        [Fact]
        public void MatchesNot()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().MatchesNot("*@*.Com").Fail();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().MatchesNot("*@*.com").Success();
            }
            {
                string foo = null;

                foo.Cond().MatchesNot(null).Fail();
            }
            {
                string foo = null;

                foo.Cond().MatchesNot("").Success();
            }
            {
                string foo = "";

                foo.Cond().MatchesNot(null).Success();
            }
            {
                string foo = "";

                foo.Cond().MatchesNot("").Fail();
            }
            {
                string foo = "";

                foo.Cond().MatchesNot("*").Fail();
            }
        }

        [Fact]
        public void MatchesEquivalentOf()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().MatchesEquivalentOf("*@*.Com").Success();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().MatchesEquivalentOf("*@*.com").Success();
            }
            {
                string foo = null;

                foo.Cond().MatchesEquivalentOf(null).Success();
            }
            {
                string foo = null;

                foo.Cond().MatchesEquivalentOf("").Fail();
            }
            {
                string foo = "";

                foo.Cond().MatchesEquivalentOf(null).Fail();
            }
            {
                string foo = "";

                foo.Cond().MatchesEquivalentOf("").Success();
            }
            {
                string foo = "";

                foo.Cond().MatchesEquivalentOf("*").Success();
            }

        }

        [Fact]
        public void MatchesNotEquivalentOf()
        {
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().MatchesNotEquivalentOf("*@*.Com").Fail();
            }
            {
                string foo = "Foo@Bar.Com";

                foo.Cond().MatchesNotEquivalentOf("*@*.com").Fail();
            }
            {
                string foo = null;

                foo.Cond().MatchesNotEquivalentOf(null).Fail();
            }
            {
                string foo = null;

                foo.Cond().MatchesNotEquivalentOf("").Success();
            }
            {
                string foo = "";

                foo.Cond().MatchesNotEquivalentOf(null).Success();
            }
            {
                string foo = "";

                foo.Cond().MatchesNotEquivalentOf("").Fail();
            }
            {
                string foo = "";

                foo.Cond().MatchesNotEquivalentOf("*").Fail();
            }

        }



        [Fact]
        public void StartsNotWith()
        {
            {
                string foo = "Mike was here";

                foo.Cond().StartsNotWith("Mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsNotWith("mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsNotWith("Miko").Success();
            }
            {
                string foo = null;

                foo.Cond().StartsNotWith("Miko").Success();
            }
            {
                string foo = "";

                foo.Cond().StartsNotWith("Miko").Success();
            }
            {
                string foo = "foo";

                foo.Cond().StartsNotWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().StartsNotWith("").Throws();
            }
        }

        [Fact]
        public void StartsWithEquivalent()
        {
            {
                string foo = "Mike was here";

                foo.Cond().StartsWithEquivalent("Mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsWithEquivalent("mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsWithEquivalent("Miko").Fail();
            }
            {
                string foo = null;

                foo.Cond().StartsWithEquivalent("Miko").Fail();
            }
            {
                string foo = "";

                foo.Cond().StartsWithEquivalent("Miko").Fail();
            }
            {
                string foo = "foo";

                foo.Cond().StartsWithEquivalent(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().StartsWithEquivalent("").Throws();
            }


        }

        [Fact]
        public void StartsNotWithEquivalentOf()
        {
            {
                string foo = "Mike was here";

                foo.Cond().StartsNotWithEquivalentOf("Mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsNotWithEquivalentOf("mike").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().StartsNotWithEquivalentOf("Miko").Success();
            }
            {
                string foo = null;

                foo.Cond().StartsNotWithEquivalentOf("Miko").Success();
            }
            {
                string foo = "";

                foo.Cond().StartsNotWithEquivalentOf("Miko").Success();
            }
            {
                string foo = "foo";

                foo.Cond().StartsNotWithEquivalentOf(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().StartsNotWithEquivalentOf("").Throws();
            }

        }

        [Fact]
        public void EndsWith()
        {
            {
                string foo = "Mike was here";

                foo.Cond().EndsWith("here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsWith("Here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsWith("hero").Fail();
            }
            {
                string foo = null;

                foo.Cond().EndsWith("hero").Fail();
            }
            {
                string foo = "";

                foo.Cond().EndsWith("hero").Fail();
            }
            {
                string foo = "foo";

                foo.Cond().EndsWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().EndsWith("").Throws();
            }
        }

        [Fact]
        public void EndsNotWith()
        {
            {
                string foo = "Mike was here";

                foo.Cond().EndsNotWith("here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsNotWith("Here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsNotWith("hero").Success();
            }
            {
                string foo = null;

                foo.Cond().EndsNotWith("hero").Success();
            }
            {
                string foo = "";

                foo.Cond().EndsNotWith("hero").Success();
            }
            {
                string foo = "foo";

                foo.Cond().EndsNotWith(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().EndsNotWith("").Throws();
            }

        }

        [Fact]
        public void EndsWithEquivalent()
        {
            {
                string foo = "Mike was here";

                foo.Cond().EndsWithEquivalent("here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsWithEquivalent("Here").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsWithEquivalent("hero").Fail();
            }
            {
                string foo = null;

                foo.Cond().EndsWithEquivalent("hero").Fail();
            }
            {
                string foo = "";

                foo.Cond().EndsWithEquivalent("hero").Fail();
            }
            {
                string foo = "foo";

                foo.Cond().EndsWithEquivalent(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().EndsWithEquivalent("").Throws();
            }

        }

        [Fact]
        public void EndsNotWithEquivalentOf()
        {
            {
                string foo = "Mike was here";

                foo.Cond().EndsNotWithEquivalentOf("here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsNotWithEquivalentOf("Here").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().EndsNotWithEquivalentOf("hero").Success();
            }
            {
                string foo = null;

                foo.Cond().EndsNotWithEquivalentOf("hero").Success();
            }
            {
                string foo = "";

                foo.Cond().EndsNotWithEquivalentOf("hero").Success();
            }
            {
                string foo = "foo";

                foo.Cond().EndsNotWithEquivalentOf(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().EndsNotWithEquivalentOf("").Throws();
            }

        }

        [Fact]
        public void Contains()
        {
            {
                string foo = "Mike was here";

                foo.Cond().Contains("was").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().Contains("Was").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().Contains("wos").Fail();
            }
            {
                string foo = null;

                foo.Cond().Contains("wos").Fail();
            }
            {
                string foo = "";

                foo.Cond().Contains("wos").Fail();
            }
            {
                string foo = "foo";

                foo.Cond().Contains(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().Contains("").Throws();
            }
        }

        [Fact]
        public void ContainsEquivalentOf()
        {
            {
                string foo = "Mike was here";

                foo.Cond().ContainsEquivalentOf("was").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().ContainsEquivalentOf("Was").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().ContainsEquivalentOf("wos").Fail();
            }
            {
                string foo = null;

                foo.Cond().ContainsEquivalentOf("wos").Fail();
            }
            {
                string foo = "";

                foo.Cond().ContainsEquivalentOf("wos").Fail();
            }
            {
                string foo = "foo";

                foo.Cond().ContainsEquivalentOf(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().ContainsEquivalentOf("").Throws();
            }
        }

        [Fact]
        public void ContainsNot()
        {
            {
                string foo = "Mike was here";

                foo.Cond().ContainsNot("was").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().ContainsNot("Was").Success();
            }
            {
                string foo = "Mike was here";

                foo.Cond().ContainsNot("wos").Success();
            }
            {
                string foo = null;

                foo.Cond().ContainsNot("wos").Success();
            }
            {
                string foo = "";

                foo.Cond().ContainsNot("wos").Success();
            }
            {
                string foo = "foo";

                foo.Cond().ContainsNot(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().ContainsNot("").Throws();
            }
        }

        [Fact]
        public void ContainsNotEquivalentOf()
        {
            {
                string foo = "Mike was here";

                foo.Cond().ContainsNotEquivalentOf("was").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().ContainsNotEquivalentOf("Was").Fail();
            }
            {
                string foo = "Mike was here";

                foo.Cond().ContainsNotEquivalentOf("wos").Success();
            }
            {
                string foo = null;

                foo.Cond().ContainsNotEquivalentOf("wos").Success();
            }
            {
                string foo = "";

                foo.Cond().ContainsNotEquivalentOf("wos").Success();
            }
            {
                string foo = "foo";

                foo.Cond().ContainsNotEquivalentOf(null).Throws();
            }
            {
                string foo = "foo";

                foo.Cond().ContainsNotEquivalentOf("").Throws();
            }


        }

        [Fact]
        public void IsEmpty()
        {
            {
                string foo = null;

                foo.Cond().IsEmpty().Fail();
            }
            {
                string foo = "";

                foo.Cond().IsEmpty().Success();
            }
            {
                string foo = " ";

                foo.Cond().IsEmpty().Fail();
            }
            {
                string foo = "Whatever";

                foo.Cond().IsEmpty().Fail();
            }
        }

        [Fact]
        public void IsNotEmpty()
        {
            {
                string foo = null;

                foo.Cond().IsNotEmpty().Success();
            }
            {
                string foo = "";

                foo.Cond().IsNotEmpty().Fail();
            }
            {
                string foo = " ";

                foo.Cond().IsNotEmpty().Success();
            }
            {
                string foo = "Whatever";

                foo.Cond().IsNotEmpty().Success();
            }
        }

        [Fact]
        public void HasLength()
        {
            {
                string foo = null;

                foo.Cond().HasLength(8).Fail();
            }
            {
                string foo = "";

                foo.Cond().HasLength(8).Fail();
            }
            {
                string foo = " ";

                foo.Cond().HasLength(8).Fail();
            }
            {
                string foo = "Whatever";

                foo.Cond().HasLength(8).Success();
            }
            {
                string foo = null;

                foo.Cond().HasLength(0).Fail();
            }
            {
                string foo = "";

                foo.Cond().HasLength(0).Success();
            }
            {
                string foo = "";

                foo.Cond().HasLength(-5).Fail();
            }
        }

        [Fact]
        public void IsNotNullOrEmpty()
        {
            {
                string foo = null;

                foo.Cond().IsNotNullOrEmpty().Fail();
            }
            {
                string foo = "";

                foo.Cond().IsNotNullOrEmpty().Fail();
            }
            {
                string foo = " ";

                foo.Cond().IsNotNullOrEmpty().Success();
            }
            {
                string foo = "Whatever";

                foo.Cond().IsNotNullOrEmpty().Success();
            }

        }

        [Fact]
        public void IsNullOrEmpty()
        {
            {
                string foo = null;

                foo.Cond().IsNullOrEmpty().Success();
            }
            {
                string foo = "";

                foo.Cond().IsNullOrEmpty().Success();
            }
            {
                string foo = " ";

                foo.Cond().IsNullOrEmpty().Fail();
            }
            {
                string foo = "Whatever";

                foo.Cond().IsNullOrEmpty().Fail();
            }

        }

        [Fact]
        public void IsNotBlank()
        {
            {
                string foo = null;

                foo.Cond().IsNotBlank().Fail();
            }
            {
                string foo = "";

                foo.Cond().IsNotBlank().Fail();
            }
            {
                string foo = " ";

                foo.Cond().IsNotBlank().Fail();
            }
            {
                string foo = "Whatever";

                foo.Cond().IsNotBlank().Success();
            }
        }

        [Fact]
        public void IsBlank()
        {
            {
                string foo = null;

                foo.Cond().IsBlank().Success();
            }
            {
                string foo = "";

                foo.Cond().IsBlank().Success();
            }
            {
                string foo = " ";

                foo.Cond().IsBlank().Success();
            }
            {
                string foo = "Whatever";

                foo.Cond().IsBlank().Fail();
            }
        }
    }
}
