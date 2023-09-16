namespace MatrixAdditionAverage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static double ComputeElementsAverage(int[,] matrix)
        {
            double average = 0;
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);
            int numElements = numRows * numCols;
            int sum = 0;

            foreach (int element in matrix) 
            {
                sum+= element;
            }

            average = sum/numElements;
            return average;
        }
    }
}