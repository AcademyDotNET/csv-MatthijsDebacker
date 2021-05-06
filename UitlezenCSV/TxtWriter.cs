using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UitlezenCSV
{
    class TxtWriter
    {
        public static void Write2DArrayToTXT(string[,] arr, int[] columns, string path, string name)
        {
            string filePath = $@"{path}{name}";
            int[] padding = new int[arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if(arr[i,j].Length > padding[j])
                    {
                        padding[j] = arr[i, j].Length;
                    }
                }
            }

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (columns[j] == 1)
                            {
                                streamWriter.Write($"{arr[i, j].PadRight(padding[j])}\t");
                            }
                        }
                        streamWriter.WriteLine("");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not write to file at {filePath}");
                Console.WriteLine(e.Message);
            }
        }
    }
}
