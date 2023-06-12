using System;
using Xunit;

namespace Domain.Tests
{
    public class ExamplesTests
    {
        [Fact]
        public void ExampleLoadTextFile_ValidNameShouldWork()
        {
            string actual = Examples.ExampleLoadTextFile("This is a valid file name.");

            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void ExampleLoadTextFile_InvalidNameShouldFail()
        {
            Assert.Throws<ArgumentException>("file", () => Examples.ExampleLoadTextFile(""));
        }
    }
}
