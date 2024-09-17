using Microsoft.QualityTools.Testing.Fakes;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Calc_Sum_2_and_3_results_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }


        [Fact]
        public void Calc_Sum_MAX_and_1_throw_OverflowEx()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 5, 6)]
        [InlineData(-1, -5, -6)]
        [InlineData(-2, 5, 3)]
        public void Calc_Sum_with_results(int a, int b, int exp)
        {
            Calc calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public void Calc_Sum_throw_overflowEx(int a, int b)
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }

        [Fact]
        public void IsWeekend()
        {
            Calc calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 16);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 17);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 18);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 19);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 20);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 21);
                Assert.True(calc.IsWeekend());//Sa                            
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 22);
                Assert.True(calc.IsWeekend());//So
            }
        }

    }
}
