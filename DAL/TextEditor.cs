using System;
using System.Collections.Generic;
using System.IO;

namespace DAL
{
    public class TextEditor
    {
        private StreamReader reader;
        private StreamWriter writer;

        public List<string> ReadFile(string filePath)
        {
            string line;
            List<string> lineList = new List<string>();

            try
            {
                using (reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineList.Add(line);
                    }
                }

                return lineList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please add Driver Information.");
                Console.ReadLine();
                return null;
            }
        }

        public void WriteLine(string filePath, string line, bool appendFile = true)
        {
            try
            {
                using (writer = new StreamWriter(filePath, appendFile))
                {
                    writer.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public void WriteFile(string filePath, string[] arrayList, bool appendFile = true)
        {
            try
            {
                using (writer = new StreamWriter(filePath, appendFile))
                {
                    foreach (var array in arrayList)
                    {
                        writer.WriteLine(array);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}