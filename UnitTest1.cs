using CalculatorProject;
using System.Collections;
using System.Diagnostics;

namespace TestingBasics
{
    public class CalculatorTests
    {
        [Fact]
        public void AdditionTest1()
        {
            //Arrange
            int a = 100;
            int b = 200;
            int excepted = 300;
            //Act
            int result = Calculator.Add(a, b);
            //Assert
            Assert.Equal(result, excepted);
        }

        [Theory]
        [InlineData(100, 200, -100)]
        [InlineData(int.MaxValue, int.MaxValue, 0)]
        [InlineData(9, 9, 0)]
        public void SubtractionTest1(int a, int b, int expected)
        {
            //Arrange

            //Act
            int result = Calculator.Subtract(a, b);
            //Assert
            Assert.Equal(expected, result);
            Assert.True(true, "false");
        }

        [Theory]
        [Trait("Calculations", "Multiplication")]
        [ClassData(typeof(MultiplyData))]
        public void MultiplyTest1(int a, int b, int expected)
        {
            //Arrange

            //Act
            int result = Calculator.Multiply(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Calculations", "Division")]
        public void DivisionTest0()
        {
            //Arrange
            int a = 2;
            int b = 0;
            //Act

            //Assert
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
        }

        [Theory]
        [Trait("Calculations", "Division")]
        [MemberData(nameof(DivisionData))]
        public void DivisionTest1(int a, int b, int expected)
        {
            //Arrange

            //Act
            int result = Calculator.Divide(a, b);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Calculations", "Division")]
        [MemberData(nameof(GetData), parameters: new object[] {3, "Bartek"})]
        public void DivisionTest2(int a, int b, int expected)
        {
            //Arrange

            //Act
            int result = Calculator.Divide(a, b);
            //Assert
            Assert.Equal(expected, result);
        }

        public class MultiplyData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 2, 2, 4 };
                yield return new object[] { 2, 3, 6 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public static IEnumerable<object[]> DivisionData => new object[][]
        {
            new object[] { 6, 3, 2 },
            new object[] { -10, 2, -5 },
            new object[] { -2, 2, -1 },
            new object[] { 10, 10, 1 },
        };

        public static IEnumerable<object[]> GetData(int numberOfTests, string name)
        {
            var testData = new object[][]
            {
                new object[] { 4, 2, 2 },
                new object[] { 8, 2, 4 },
                new object[] { 12, 2, 6 },
                new object[] { 20, 10, 2 },
            };

            return testData.Take(numberOfTests);
        }
    }
}