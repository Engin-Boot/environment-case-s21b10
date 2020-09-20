using System;

namespace Receiver
{
    public delegate string AlertDelegate(string parameterName, string message, string parameterValue);
    class Program
    {
        static int Main()
        {
            string ReadConsole()
            {
                string data = Console.ReadLine();
                return data;
            }

            Analyzer analyzeObj = new Analyzer();
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;


            string receivedData;
            while ((receivedData = ReadConsole()) != null)
            {
                analyzeObj.DataInterpretation(receivedData, alertDelObj);
                //return 1;
            }

            Console.ReadLine();
            return 0;
        }
    }

}
