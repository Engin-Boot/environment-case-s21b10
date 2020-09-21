using System;
namespace Sender
{
    public abstract class DataSender
    {
        public abstract string SendDataToReceiverViaConsole(string data);
    }

    public class DataSenderViaConsole : DataSender
    {
        public override string SendDataToReceiverViaConsole(string data)
        {

            Console.WriteLine(data);
            return data;

        }
    }
}
