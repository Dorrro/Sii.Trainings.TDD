namespace Sii.Trainings.TDD.Tests.LegacyCode
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class LegacyCodeTests
    {
        [Fact]
        public void When_WriteIsCalled_Should_WriteToIWriter()
        {
            // arrange
            var writer = Substitute.For<IWriter>();
            var legacyCode = new LegacyCode(writer, YetAnotherHorribleSingleton.Instance.IsRestaurantOpen);

            // act
            legacyCode.Write();

            // arrange
            writer.Received(1).Write();
        }

        [Fact]
        public void When_CustomerIsOver60IsOk_Should_ReturnTrue()
        {
            // arrange
            var customer = new Customer { Age = 61 };
            var writer = Substitute.For<IWriter>();
            var legacyCode = new LegacyCode(writer, true);

            // act
            var isCustomerOk = legacyCode.IsCustomerOk(customer);

            // arrange
            isCustomerOk.Should()
                .BeTrue();
        }

        [Fact]
        public void BUG_When_CustomerIsNullIsOk_Should_ReturnFalse()
        {
            // arrange
            var writer = Substitute.For<IWriter>();
            var legacyCode = new LegacyCode(writer, true);

            // act
            var isCustomerOk = legacyCode.IsCustomerOk(null);

            // arrange
            isCustomerOk.Should()
                .BeFalse();
        }
    }

    public interface IWriter
    {
        void Write();
    }
}