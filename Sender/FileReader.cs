using System;
using System.Collections.Generic;
using System.IO;


namespace Sender
{
    public class FileReader
    {
        public bool CheckHeader(String line)
        {

            return (line.Contains("Temperature") && line.Contains("Humidity"));
        }

        public List<string> CheckFileExists(string path)
        {
            if (File.Exists(path))
            {
                var dataList = ReadCsvFromFile(path);
                return dataList;
            }
            else
            {
                Console.WriteLine("File does not exist");
                return null;
            }
        }
        public List<string> ReadCsvFromFile(string path)
        {
            var dataList = new List<string>();
            using (TextReader sr = new StreamReader(path))
            {
                var line = sr.ReadLine();

                if (!CheckHeader(line))
                {
                    dataList.Add(line);
                }

                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    dataList.Add(line);

                }
            }

            return dataList;
        }

    }


 }
