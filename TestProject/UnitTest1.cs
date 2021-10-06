using Calculator;
using System;
using Xunit;

namespace TestProject_Calculator
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new double[] { 10, 10, 10, 10, 10 }, 50)]
        [InlineData(new double[] { 0, 10, 20, 30, 40 }, 100)]
        [InlineData(new double[] { 100, 90, 0, 50, 0 }, 240)]
        public void AdditionArrayCalculationTest(double[] inputArray, double expected)
        {
            double actualResult = Program.Addition(inputArray);

            Assert.Equal(expected, actualResult);
        }

        [Theory]
        [InlineData(100, -140, -40)] //100 + -140
        [InlineData(-100, -100, -200)] //-100 + -100
        [InlineData(100, 50, 150)] //100 + 50
        public void AdditionCalculation(double input1, double input2, double expected)
        {
            double result = Program.Addition(input1, input2);

            Assert.Equal(expected, result);
        }

        //Inlinedata(param, expected value)
        [Theory]
        [InlineData(new double[] { 100, 10, 10, 10, 10 }, -140)]
        [InlineData(new double[] { 0, 10, 20, 30, 40 }, -100)]
        [InlineData(new double[] { 100, 90, 0, 50, 0 }, -240)]
        public void SubtractionnArrayCalculationTest(double[] inputArray, double expected)
        {
            double actualResult = Program.Subtraction(inputArray);

            Assert.Equal(expected, actualResult);
        }

        [Theory]
        [InlineData(100, -140, 240)] //100 - -140
        [InlineData(-100, -100, 0)] //-100 - -100
        [InlineData(100, 50, 50)] //100-50
        public void SubtractionCalculation(double input1, double input2, double expected)
        {
            double result = Program.Subtraction(input1, input2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, -14, -140)] //10 * -14
        [InlineData(-100, -100, 10000)] //-100 * -100
        [InlineData(100, 50, 5000)] //100 * 50
        [InlineData(-10, 50, -500)] //-10 * 50
        public void MultiplicationCalculation(double input1, double input2, double expected)
        {
            double result = Program.Multiplication(input1, input2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 5)] //10 / 2
        [InlineData(10, -5, -2)] //10 / -5
        public void DivisionCalculation(double input1, double input2, double expected)
        {
            double result = Program.Division(input1, input2);

            Assert.Equal(expected, result);
        }

        // Throws exception if trying to divide by zero
        [Theory]
        [InlineData(10, 0)]
        public void DivideWithZeroCalculation(double input1, double input2)
        {
            DivideByZeroException result = Assert.Throws<DivideByZeroException>(() => double.IsInfinity(Program.Division(input1, input2)));

            Assert.Equal(new DivideByZeroException().Message, result.Message);
        }

    }
}
