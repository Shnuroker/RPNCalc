using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReversePolishNotationCalculator
{
    public class ReversePolishNotationTests
    {
        // Факт на проверку правильности работы главного метода (+)
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(25, ReversePolishNotation.Calculate("6 10 + 4 - 1 1 2 * + / 1 + 2 ^"));
        }

        // Факт на вывод 1 исключения: строка с символом не являющимся цифрой или оператором (-)
        [Fact]
        public void FailingTestEx1()
        {
            Assert.Equal(30, ReversePolishNotation.Calculate("3 3 ^ r +"));
        }

        // Факт на вывод 2 исключения: в стеке не хватает одного элемента для выполнения операции  (-)
        [Fact]
        public void FailingTestEx2()
        {
            Assert.Equal(30, ReversePolishNotation.Calculate("4 4 ^ 5 + /"));
        }

        // Факт на вывод 3 исключения: в стеке более одного элемента на вывод (-)
        [Fact]
        public void FailingTestEx3()
        {
            Assert.Equal(30, ReversePolishNotation.Calculate("4 4"));
        }

        // Теория на проверку правильности работы главного метода (3+)
        [Theory]
        [InlineData("5 4 + 3 / 2 +")] // (+)
        [InlineData("2 2 ^ 5 5 / +")] // (+)
        [InlineData("49 7 / 3 2 ^ - 7 +")] // (+)
        public void PassingTheory(string value)
        {
            Assert.Equal(5, ReversePolishNotation.Calculate(value));
        }
    }
}
