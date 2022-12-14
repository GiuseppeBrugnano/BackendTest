using System;
using System.IO;

namespace TestBackend
{
    class Program
    {

        //search function
        public static string searchResult(int columnNumber, string[] rows, string key)
        {

            foreach (string row in rows)
            {
                string[] value = row.Split(',');

                if (columnNumber > value.Length - 1 || columnNumber <= 0)
                {
                    return "Column number out of bounds.";
                }

                if (value[columnNumber] == key)
                {
                    return row;
                }
            }

            return "No row found searching by key " + key;

        }

        //main
        static void Main(string[] args)
        {

            if (args.Length != 3)
            {
                Console.WriteLine("Wrong parameter quantity given.");
                return;
            }

            string path = args[0];

            if (!int.TryParse(args[1], out int columnNumber))
            {
                Console.WriteLine("The column number must be an integer.");
                return;
            }

            string key = args[2];

            try
            {
                string[] rows = File.ReadAllLines(path);
                string result = searchResult(columnNumber, rows, key);
                Console.WriteLine(result);
            }
            catch
            {
                Console.WriteLine("Invalid path");
            }
            return;

        }
    }
}