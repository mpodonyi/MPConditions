using System;
using FluentAssertions;

using Xunit;

namespace MPConditions.Test
{

    public class ThrowTest
    {
        public ThrowTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [Fact]
        public void Throw_ThrowsArgumentNullException_Success()
        {
            string foo = null;

            Action act = () => foo.Cond("foo").IsNotNull().Throw();

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Throw_ThrowsArgumentNullException_Fail()
        {
            string foo = "foo";

            Action act = () => foo.Cond("foo").IsNotNull().Throw();

            act.ShouldNotThrow();
        }

    }
}
