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
            StreamReader streamReader = null;
            string file = "";
            try
            {
                streamReader = new StreamReader(path);
                file = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not read the file at {path}");
                Console.WriteLine(e.Message);
            }

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

            if (streamReader != null)
            {
                streamReader.Close();
                streamReader.Dispose();
            }

            return data;
        }
    }
}
