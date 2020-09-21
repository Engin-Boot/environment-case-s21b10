using System;

using System.Threading;


namespace Sender
{
    class Program
    {
        static void Main()
        {
           // string path = @"D:\C#\EnvironmentCaseStudy\Sender\bin\Debug\TemperatureAndHumidityData.csv";
            string path = @"D:\a\environment-case-s21b10\environment-case-s21b10\TemperatureAndHumidityData.csv";
            FileReader readFile = new FileReader();
            DataSenderViaConsole sendData=new DataSenderViaConsole();

            
            var data = readFile.CheckFileExists(path);
            if (data.Count == 0)
            {
                Console.WriteLine("CSV FILE EMPTY");
            }
            else
            {
                foreach (string dataRead in data)
                {
                    sendData.SendDataToReceiverViaConsole(dataRead);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}

