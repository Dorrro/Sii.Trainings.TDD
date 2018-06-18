namespace Sii.Trainings.TDD.Tests
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using NSubstitute.ExceptionExtensions;
    using NSubstitute.Exceptions;
    using Xunit;

    public class RefereeGivesCardTests
    {
        private static IVAR _var;
        private static Referee _referee;

        // jesteśmy sędzią, który korzysta z systemu VAR
        // 1. Jeśli sędzia jest pewien, że faul był, to daje kartkę
        // 2. Jeśli sędzia nie jest pewien, to pyta się system VAR o pomoc i jeśli:
        //      a. VAR mówi, że jest faul, to daje kartkę,
        //      b. VAR mówi, że faulu nie było, to kartki nie daje.
        //      c. System VAR nie odpowiada, to nie daje kartki

        [Fact]
        public void When_RefereeIsSure_Should_GiveCard()
        {
            // arrange

            // act
            var result = _referee.GiveCard(isSure: true);

            // assert
            result.Should()
                .BeTrue();
        }

        [Fact]
        public void When_RefereeIsNotSure_Should_AskVARForHelp()
        {
            // arrange

            // act
            _referee.GiveCard(isSure: false);

            // assert
            _var.Received(1)
                .ConfirmFoul();
        }

        public RefereeGivesCardTests()
        {
            _var = Substitute.For<IVAR>();
            _referee = new Referee(_var);
        }

        [Fact]
        public void When_RefereeIsNotSureAndVarConfirms_Should_GiveCard()
        {
            // arrange
            _var.ConfirmFoul()
                .Returns(true);

            // act
            var result = _referee.GiveCard(isSure: false);

            // assert
            result.Should()
                .BeTrue();
        }

        [Fact]
        public void When_RefereeIsNotSureAndVarDenies_Should_NotGiveCard()
        {
            // arrange
            _var.ConfirmFoul()
                .Returns(false);

            // act
            var result = _referee.GiveCard(isSure: false);

            // assert
            result.Should()
                .BeFalse();
        }

        [Fact]
        public void When_RefereeIsNotSureAndVarIsNotResponding_Should_NotGiveCard()
        {
            // arrange
            _var.ConfirmFoul()
                .Throws<Exception>();

            // act
            var result = _referee.GiveCard(isSure: false);

            // assert
            result.Should()
                .BeFalse();
        }

    }

    public interface IVAR
    {
        bool ConfirmFoul();
    }

    public class VAR : IVAR
    {
        public bool ConfirmFoul()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Referee
    {
        private readonly IVAR _var;

        public Referee(IVAR var)
        {
            this._var = var;
        }

        public bool GiveCard(bool isSure)
        {
            if (isSure)
                return true;

            bool confirmed;
            try
            {
                confirmed = this._var.ConfirmFoul();
            }
            catch
            {
                confirmed = false;
            }

            return confirmed;
        }
    }
}
