using System;
using System.Timers;


namespace Receiver
{
    public delegate void AlertDelegate(string parameterName, string message, string parameterValue);
    class Program
    {
        static void Main(string[] args)
        {
            
            
        string Readconsole()
            {
                string data = Console.ReadLine();
                return data;
            }

            Analyzer analyzeObj = new Analyzer();
           // ConsoleAlerter alerter = new ConsoleAlerter();
            //AlertDelegate alertDelObj = alerter.SendAlert;


            string receiveddata;
            while ((receiveddata = Readconsole()) != null)
            {
                //analyzeObj.DataInterpretation(receiveddata, alertDelObj);
            }

        }
    }
}
