namespace Sii.Trainings.TDD.Tests
{
    using FluentAssertions;
    using Xunit;

    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(21)]
        [InlineData(24)]
        [InlineData(27)]
        public void When_NumberIsDivisibleBy3_Should_ReturnFizz(int number)
        {
            // arrange
            var fizzBuzz = new FizzBuzz();

            // act
            var result = fizzBuzz.Get(number);

            // assert
            result.Should()
                .Be("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        [InlineData(40)]
        [InlineData(50)]
        [InlineData(55)]
        public void When_NumberIsDivisibleBy5_Should_ReturnBuzz(int number)
        {
            // arrange
            var fizzBuzz = new FizzBuzz();

            // act
            var result = fizzBuzz.Get(number);

            // assert
            result.Should()
                .Be("Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(75)]
        [InlineData(90)]
        [InlineData(105)]
        public void When_NumberIsDivisibleByEither3And5_Should_ReturnFizzBuzz(int number)
        {
            // arrange
            var fizzBuzz = new FizzBuzz();

            // act
            var result = fizzBuzz.Get(number);

            // assert
            result.Should()
                .Be("FizzBuzz");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(11)]
        [InlineData(7)]
        [InlineData(8)]
        public void When_NumbersIsNeitherDivisibleBy3Nor5_Should_ReturnThatNumber(int number)
        {
            // arrange
            var fizzBuzz = new FizzBuzz();

            // act
            var result = fizzBuzz.Get(number);

            // assert
            result.Should()
                .Be(number.ToString());
        }
    }

    public class FizzBuzz
    {
        public string Get(int i)
        {
            if (i % 3 != 0 && i % 5 != 0)
                return i.ToString();

            if (i % 15 == 0)
                return "FizzBuzz";

            if (i % 5 == 0)
                return "Buzz";

            return "Fizz";
        }
    }
}
