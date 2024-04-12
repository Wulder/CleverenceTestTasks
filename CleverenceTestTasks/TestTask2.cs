

namespace CleverenceTestTasks
{
    internal class TestTask2
    {

        public static int[] GetSpiralArray(int[,] matrix)
        {
            int[] result = new int[matrix.Length];

            SpiralPointer sPointer = new SpiralPointer(matrix.GetLength(1), matrix.GetLength(0));


            for (int i = 0; i < matrix.Length; i++)
            {
                var pointer = sPointer.MoveNext();
                result[i] = matrix[(int)pointer.Y, (int)pointer.X];
            }

            return result;
        }

        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
