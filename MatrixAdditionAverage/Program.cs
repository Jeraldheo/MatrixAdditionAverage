using System.Text;

namespace MatrixAdditionAverage
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix = new double[,] { { 17, 9, 36 }, { 8, 7, 3 }, { 15, 28, 57 } };
            double average = ComputeElementsAverage(matrix);
            double percentage = ComputePercentage(average, 60);
            double[] acceptanceInterval = GetAcceptaceInterval(average, percentage);
            List<double> acceptedElementsForSum = GetAcceptedElementsForSum(matrix, acceptanceInterval);
            List<double> notAcceptedElementsForSum = GetNotAcceptedElementsForSum(matrix, acceptanceInterval);

            Console.WriteLine($"La suma es: {acceptedElementsForSum.Sum()}");
            Console.WriteLine($"Promedio: {average}");
            Console.WriteLine($"No aplican para sumar: {ListToString(notAcceptedElementsForSum)}");
            Console.WriteLine($"Sí aplican para sumar: {ListToString(acceptedElementsForSum)}");

            

        }

        public static double ComputeElementsAverage(double[,] matrix)
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

        public static double ComputePercentage(double value, double percentage)
        {
            double percentageResult = value * (percentage / 100);
            return percentageResult;
        }
        public static double[] GetAcceptaceInterval(double center, double distance)
        {
            double[] interval = {0, 0};
            double leftEndpoint = center - distance;
            double rightEndpoint = center + distance;

            interval[0] = leftEndpoint;
            interval[1] = rightEndpoint;

            return interval;
        }

        public static List<double> GetAcceptedElementsForSum(double[,] matrix, double[] interval)
        {
            List<double> acceptedElements = new List<double>();
            foreach(double element in matrix)
            {
                if (interval[0]<=element && element <= interval[1])
                {
                    acceptedElements.Add(element);
                }
            }
            return acceptedElements;
        }

        public static List<double> GetNotAcceptedElementsForSum(double[,] matrix, double[] interval)
        {
            List<double> notAcceptedElements = new List<double>();
            foreach(double element in matrix)
            {
                if (element < interval[0] || interval[1] < element)
                {
                    notAcceptedElements.Add(element);
                }
            }
            return notAcceptedElements;
        }

        private static string ListToString(List<double> list)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int size = list.Count;

            for(int i = 0; i<size-1; i++)
            {
                stringBuilder.Append(list[i] + ", ");
            }

            stringBuilder.Append(list[size - 1]);
            return stringBuilder.ToString();
        }
    }
}