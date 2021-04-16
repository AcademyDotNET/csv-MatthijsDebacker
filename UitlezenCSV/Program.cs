using System;

namespace UitlezenCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = CsvReader.ReadCSV(@"C:\Users\Gebruiker\Desktop\barometer_2019 S1.csv");

            Print2DArray(data);

            DateTime date = DateTime.Now;
            
            TxtWriter.Write2DArrayToTXT(data, @"C:\Users\Gebruiker\Desktop\", $"{date.Date.ToString("ddMMyyyy")}.txt");
        }

        static void Print2DArray(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{ arr[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
