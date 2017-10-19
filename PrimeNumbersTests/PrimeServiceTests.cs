using System;
using Xunit;
using PrimeNumbers;

namespace PrimeNumbersTests
{
    public class PrimeServiceTest
    {
        private readonly PrimeService primeService;
        public PrimeServiceTest()
        {
            primeService = new PrimeService();
        }

        [Fact]
        public void Given1ReturnFalse()
        {
            var result = primeService.isPrime(1);
            Assert.False(result, "1 should not be a prime");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void GivenLessThan2ReturnFalse(int value)
        {
            var result = primeService.isPrime(value);
            Assert.False(result, "Anything less than 2 is not a prime");
        }

        [Fact]
        public void Given2ReturnTrue()
        {
            Assert.True(primeService.isPrime(2));
        }

        [Fact]
        public void Given3ReturnTrue()
        {
            var res = primeService.isPrime(3);
            Assert.True(res);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(12)]
        [InlineData(1000)]
        public void GivenEvenReturnFalse(int value)
        {
            var res = primeService.isPrime(value);
            Assert.False(res);
        }

        [Theory]
        [InlineData(1019)]
        [InlineData(2371)]
        [InlineData(4057)]
        [InlineData(6947)]
        public void GivenKnownLargePrimesReturnTrue(int value)
        {
            Assert.True(primeService.isPrime(value));    
        }

        [Theory]
        [InlineData(1023)]
        [InlineData(3825)]
        [InlineData(4593)]
        public void GivenKnownLargeNonPrimesReturnFalse(int value)
        {
            Assert.False(primeService.isPrime(value));
        }

        [Fact]
        public void ForRangeFrom1To1ReturnsEmptyArray()
        {
            var result = primeService.GetPrimesInRange(1,1);
            Assert.Empty(result);
        }

        [Fact]
        public void ForRangeFrom1To2ReturnArrayOfItem2()
        {
            var result = primeService.GetPrimesInRange(1,2);
            Assert.Collection(result, item => Assert.Equal(2,item));
        }

        [Fact]
        public void ForRangeFrom1To3ReturnArraOfItems2and3()
        {
            var result = primeService.GetPrimesInRange(1,3);
            Assert.Collection(result, item => Assert.Equal(2,item), item => Assert.Equal(3,item));
        }

        [Theory]
        [InlineData(1,5,new int[] {2,3,5})]
        [InlineData(10,20,new int[] {11,13,17,19})]
        [InlineData(170,200,new int[] {173,179,181,191,193,197,199})]
        public void ForRangeFromAtoBReturnArraOfItemsC(int a, int b, int[] c)
        {
            var result = primeService.GetPrimesInRange(a,b);
            Assert.Equal<int[]>(c, result);
        }
    }
}
