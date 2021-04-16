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
        public static void Write2DArrayToTXT(string[,] arr, string path, string name)
        {
            string filePath = $@"{path}{name}";

            using(StreamWriter streamWriter = new StreamWriter(filePath))
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        streamWriter.Write($"{arr[i,j]}\t");
                    }
                    streamWriter.WriteLine("");
                }
            }
        }
    }
}
