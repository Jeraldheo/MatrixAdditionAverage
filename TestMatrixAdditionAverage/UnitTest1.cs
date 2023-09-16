using MatrixAdditionAverage;

namespace TestMatrixAdditionAverage
{
    public class UnitTest1
    {
        public static IEnumerable<object[]> TestData
            => new[]
            {
                new object[]{20, new int[,]{ {17, 9, 36},{8, 7, 3}, {15, 28, 57} } },
                new object[]{10, new int[,]{ {20, 9, 12},{8, 7, 3}, {10, 20, 1} } },
                new object[]{0, new int[,]{ {0, 0, 0},{0, 0, 0}, {0, 0, 0} } },
                new object[]{9, new int[,]{ {9, 9, 9},{9, 9, 9}, {9, 9, 9} } }
            };
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test_ComputeAverage(double expectedAverage, int[,] matrix)
        {
            double average = Program.ComputeElementsAverage(matrix);
            Assert.Equal(expectedAverage, average);
        }
    }
}