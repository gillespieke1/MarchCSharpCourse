using System;
using Xunit;

namespace BankingTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(30, 10 + 20);
        }

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(3,2,5)]
        [InlineData(5,5,10)]
        public void AddingTwoNumbers(int a, int b, int expectedSum)
        {
            int answer = a + b;

            Assert.Equal(expectedSum, answer);
        }
    }
}
