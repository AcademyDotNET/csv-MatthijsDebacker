using System;

namespace UitlezenCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = CsvReader.ReadCSV(@"C:\Users\Gebruiker\Desktop\pokemon.csv");

            Print2DArray(data);

            DateTime date = DateTime.Now;

            int[] cols = new int[data.GetLength(1)];
            int input = 0;
            do
            {
                input = AskForInt("Which column do you wish to print? Enter a negative number to stop.");
                if (input < data.GetLength(0) && input >= 0)
                {
                    cols[input] = 1;
                }
            } while (input >= 0);

            
            TxtWriter.Write2DArrayToTXT(data, cols, @"C:\Users\Gebruiker\Desktop\", $"pokemon_{date.Date.ToString("ddMMyyyy")}.txt");
        }

        static int AskForInt(string question, string errorResponse = "Invalid number, please try again", bool clear = false)
        {
            Console.WriteLine(question);
            int input = 0;

            string sInput = Console.ReadLine();
            while (!int.TryParse(sInput, out input))
            {
                if (clear)
                {
                    Console.Clear();
                }
                Console.WriteLine(errorResponse);
                sInput = Console.ReadLine();
            }

            return input;
        }

        static void Print2DArray(string[,] arr, bool pad = false)
        {
            int[] padding = new int[arr.GetLength(1)];

            if (pad)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if(arr[i, j].Length > padding[j])
                        {
                            padding[j] = arr[i, j].Length;
                        }
                    }
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j].PadRight(padding[j], ' ')}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
