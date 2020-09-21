namespace Sender
{
    class Program
    {
        static void Main()
        {
           // string path = @"D:\C#\EnvironmentCaseStudy\Sender\bin\Debug\TemperatureAndHumidityData.csv";
            string path = @"D:\a\environment-case-s21b10\environment-case-s21b10\TemperatureAndHumidityData.csv";
            DataSenderViaConsole sendData=new DataSenderViaConsole();
            sendData.SendDataToReceiver(path);
        }
    }
}

