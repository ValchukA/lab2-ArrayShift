using System;
using System.IO;

namespace ArrayShift
{
    class Program
    {
        public static int[,] Fill(string pathToFile)
        {
            int[,] arr;

            using (var reader = File.OpenText(pathToFile))
            {
                int length = Convert.ToInt32(reader.ReadLine());
                arr = new int[length, length];

                int rowCounter = 0;

                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] row = line.Split();

                    for (int i = 0; i < row.Length; i++)
                    {
                        arr[rowCounter, i] = Convert.ToInt32(row[i]);
                    }

                    rowCounter++;
                }
            }

            return arr;
        }
        static void Main()
        {
            int[,] arr = Fill("Inlet.in.txt");
            arr.Shift();
            arr.PrintToFile("Outlet.out.txt");
        }
    }
}
