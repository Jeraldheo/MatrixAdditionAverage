using MatrixAdditionAverage;

namespace TestMatrixAdditionAverage
{
    public class TestProgram
    {
        public static IEnumerable<object[]> TestDataComputeAverage
            => new[]
            {
                new object[]{20, new int[,]{ {17, 9, 36},{8, 7, 3}, {15, 28, 57} } },
                new object[]{10, new int[,]{ {20, 9, 12},{8, 7, 3}, {10, 20, 1} } },
                new object[]{0, new int[,]{ {0, 0, 0},{0, 0, 0}, {0, 0, 0} } },
                new object[]{9, new int[,]{ {9, 9, 9},{9, 9, 9}, {9, 9, 9} } }
            };
        [Theory]
        [MemberData(nameof(TestDataComputeAverage))]
        public void Test_ComputeAverage(double expectedAverage, int[,] matrix)
        {
            double average = Program.ComputeElementsAverage(matrix);
            Assert.Equal(expectedAverage, average);
        }

        public static IEnumerable<object[]> TestDataComputePercentage
            => new[]
            {
                new object[]{12, 20, 60},
                new object[]{60, 100, 60},
                new object[]{25, 50, 50},
                new object[]{1, 10, 10},

            };
        [Theory]
        [MemberData(nameof(TestDataComputePercentage))]
        public void Test_ComputePercentage(double expectedPercentage, double value, double percentage)
        {
            double percentageResult = Program.ComputePercentage(value, percentage);
            Assert.Equal(expectedPercentage, percentageResult);
        }

        public static IEnumerable<object[]> TestDataGetAcceptanceInterval
            => new[]
            {
                new object[]{new double[]{8, 32}, 20, 12},
                new object[]{new double[]{-1, 1}, 0, 1},
                new object[]{new double[]{7, 13}, 10, 3}

            };

        [Theory]
        [MemberData(nameof(TestDataGetAcceptanceInterval))]
        public static void Test_GetAcceptanceInterval(double[] expectedInterval, double center, double distance)
        {
            double[] interval = Program.GetAcceptaceInterval(center, distance);
            Assert.True(interval.SequenceEqual(expectedInterval));
        }
    }
}