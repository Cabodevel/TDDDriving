using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace TDD.Tests
{
    public class CalcService_Tests
    {
        private readonly CalcService sut;

        //Refactorización de los tests
        //Un test no puede afectar al otro
        //Se trata de test unitarios, así que deben ser totalmente independientes en su ejecución
        public CalcService_Tests()
        {
            //Arrange
            sut = new CalcService();
        }

        //Red
        //Green
        //Refactor

        [Fact]
        public void Exists()
        {
            sut.ShouldNotBeNull();
        }

        //Por norma general, se hacen las pruebas de errores antes que la de validación
        [Theory]
        [MemberData(nameof(InvalidInputs))]
        public void Sum_GivenInvalidValue_ShouldThrowArgumentException(int num1, int num2)
        {
            //Act //Assert
            Should.Throw<ArgumentException>(() => sut.Sum(num1, num2));
        }

        public static IEnumerable<object[]> InvalidInputs => new List<object[]>
        {
            new object[]
            {
                0,
                1
            },
            new object[]
            {
                1,
                0
            },
        };

        //Esto sería un test de regresión
        //ya que evita que si realizamos un cambio
        //cambie el comportamiento del método
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,1,3)]
        [InlineData(2,2,4)]
        public void Sum_ShouldRetunExpected(int num1, int num2, int expected)
        {
            //Act se realizan las acciones necesarias para el test
            int result = sut.Sum(num1, num2);

            //Assert se comprueba que se devuelve lo esperado
            result.ShouldBe(expected);
        }
    }
}
