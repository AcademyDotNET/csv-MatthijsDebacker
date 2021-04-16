using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UitlezenCSV
{
    class CsvReader
    {
        public static string[,] ReadCSV(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string file = streamReader.ReadToEnd();
            string[] lines = file.Split("\n");
            string[] header = lines[0].Split(",");
            string[,] data = new string[lines.Length - 1,header.Length];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                string[] line = lines[i].Split(",");
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = line[j];
                }
            }

            streamReader.Close();
            streamReader.Dispose();

            return data;
        }
    }
}
