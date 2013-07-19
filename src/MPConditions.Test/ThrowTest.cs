using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using MPConditions;
using MPConditions.DefaultExtensions;
using MPConditions.ThrowExtensions;
using System.Linq;
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

            Action act = () => foo.Condition("foo").NotNull().Throw();

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Throw_ThrowsArgumentNullException_Fail()
        {
            string foo = "foo";

            Action act = () => foo.Condition("foo").NotNull().Throw();

            act.ShouldNotThrow();
        }

    }
}
