using System;
namespace Receiver
{
public abstract class Alerter
    {
        public abstract string SendAlert(string parameterName, string message, string parameterValue);
    }

    public class ConsoleAlerter : Alerter
    {
        public override string SendAlert(string parameterName, string message, string parameterValue)
        {
            Console.WriteLine($"{parameterName} {message} {parameterValue}");
            return $"{parameterName} {message} {parameterValue}";
        }
    }
       
    
}
