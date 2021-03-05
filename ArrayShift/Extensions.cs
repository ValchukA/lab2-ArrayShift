using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArrayShift
{
    public static class Extensions
    {
        private static void Swap<T>(ref T first, ref T second)
        {
            T tmp = first;
            first = second;
            second = tmp;
        }

        public static void Shift<T>(this T[,] arr)
        {
            if (arr.GetLength(0) <= 1)
            {
                throw new Exception("Matrix must have at least 2 rows.");
            }

            if (arr.GetLength(0) != arr.GetLength(1))
            {
                throw new Exception("Matrix must be square.");
            }

            int length = arr.GetLength(0);

            T tmp;

            for (int i = 0; i < length - 1; i++)
            {
                tmp = arr[i, length - 1];
                arr[i, length - 1] = arr[0, i];
                Swap(ref arr[length - 1, length - 1 - i], ref tmp);
                Swap(ref arr[length - 1 - i, 0], ref tmp);
                arr[0, i] = tmp;
            }
        }

        public static void PrintToFile<T>(this T[,] arr, string pathToFile)
        {
            List<StringBuilder> data = new List<StringBuilder>();

            for (int row = 0; row <= arr.GetUpperBound(0); row++)
            {
                var line = new StringBuilder();

                for (int col = 0; col < arr.GetUpperBound(1); col++)
                {
                    line.Append($"{arr[row, col]} ");
                }

                line.Append(arr[row, arr.GetUpperBound(1)]);

                data.Add(line);
            }

            using (var writer = File.CreateText(pathToFile))
            {
                foreach (var line in data)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
