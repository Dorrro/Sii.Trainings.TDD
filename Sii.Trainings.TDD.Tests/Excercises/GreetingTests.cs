namespace Sii.Trainings.TDD.Tests.Excercises
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    // 1. Napisz metodę Hello(name), która łączy name z jakimś prostym powitaniem.
    // Np. gdy name to Roman, to metoda powinna zwrócić "Cześć Roman!"
    // 2. Obsłuż nulle. Gdy name jest nullem, to na ekran wypisz np. "Witaj kolego!"
    // 3. Obsłuż krzyczenie. Gdy całe imię "MATEUSZ" jest wielkimi literami,
    // to metoda powinna zwrócić "CZEŚĆ MATEUSZ!"
    // 4. Obsłuż dwa imiona. Gdy do Hello przekażę 2 parametry, np. Hello("Gosia", "Adrian"),
    // to metoda powinna zwrócić "Cześć Gosia i Adrian!"
    // 5. Obsłuż tablicę imion (params). Metoda Hello("Paweł", "Dorian", "Mikołaj")
    // powinna zwrócić "Cześć Paweł, Dorian i Mikołaj!"
    // 6. Zezwól na mieszanie imion krzyczanych i normalnych. Metoda
    // Hello("Roman", "MATEUSZ", "Paweł") powinna
    // zwrócić "Cześć Roman i Paweł. O, CZEŚĆ MATEUSZ!"
    // 7. Jeśli parametr zawiera przecinek, to dany element powinien zostać podzielony
    // i traktowany jako dwa oddzielne elementy. Np Hello("Jan", "Maria, Rokita")
    // powinno zwrócić "Cześć Jan, Maria i Rokita!"
    // 8. Pozwól na traktowanie parametru z przecinkiem jako jeden element
    // przez wprowadzenie elementu escapującego, np Hello("'Anna, Maria'") powinno zwrócić "Cześć Anna, Maria!"
    public class GreetingTests
    {
        [Theory]
        [InlineData("Roman")]
        [InlineData("Gosia")]
        [InlineData("Mateusz")]
        public void When_NameIsProvided_Should_ReturnNameWithGreeting(string name)
        {
            // arrange
            var greeting = new Greeting();
            // act
            var hello = greeting.Hello(name);
            // assert
            hello.Should()
                .Be($"Cześć {name}!");
        }

        [Fact]
        public void When_NameIsNull_Should_ReturnGenericGreeting()
        {
            // arrange
            var greeting = new Greeting();

            // act
            var hello = greeting.Hello(null);

            // assert
            hello.Should()
                .Be("Witaj kolego!");
        }

        [Theory]
        [InlineData("ROMAN")]
        [InlineData("MATEUSZ")]
        [InlineData("GOSIA")]
        public void When_NameIsUppercased_Should_ReturnUppercasedGreeting(string name)
        {
            // arrange
            var greeting = new Greeting();

            // act
            var hello = greeting.Hello(name);

            // assert
            hello.Should()
                .Be($"CZEŚĆ {name}!");
        }

        [Theory]
        [InlineData("Gosia", "Adrian")]
        [InlineData("Roman", "Paweł")]
        public void When_Given2Names_Should_ReturnCombinedGreeting(string name1, string name2)
        {
            var greeting = new Greeting();
            var hello = greeting.Hello(name1, name2);
            hello.Should()
                .Be($"Cześć {name1} i {name2}");
        }

        [Theory]
        [InlineData("Gosia", "Adrian", "Paweł")]
        [InlineData("Gosia", "Adrian", "Paweł", "Mateusz")]
        public void When_GivenAnyNumberOfNames_Should_ReturnCombinedGreeting(params string[] names)
        {
            var greeting = new Greeting();
            var namesSeparatedWithComma = names.Take(names.Length - 1)
                .Join(", ");
            var lastNameOfNames = names[names.Length - 1];
            var expected = $"Cześć {namesSeparatedWithComma} i {lastNameOfNames}";

            var hello = greeting.Hello(names);

            hello.Should()
                .Be(expected);
        }
    }

    public static class IEnumerableExtensions
    {
        public static string Join(this IEnumerable<string> enumerable, string delimeter)
        {
            return string.Join(delimeter, enumerable);
        }
    }


    public class Greeting
    {
        public string Hello(params string[] name)
        {
            if (name == null)
                return "Witaj kolego!";

            if (name[0]
                    .ToUpper() == name[0])
                return $"CZEŚĆ {name[0]}!";

            if(name.Length == 1)
                return $"Cześć {name[0]}!";

            var result = "Cześć ";
            for (var i = 0; i < name.Length - 2; i++)
            {
                result = result + name[i] + ", ";
            }

            return result + name[name.Length - 2] + " i " + name[name.Length - 1];

        }
    }
}