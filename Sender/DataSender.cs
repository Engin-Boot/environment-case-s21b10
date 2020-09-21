using System;
using System.Threading;

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
         public int SendDataToReceiver(string path)
        {
            FileReader readFile = new FileReader();
            var data = readFile.CheckFileExists(path);
            if (data.Count == 0)
            {
                Console.WriteLine("CSV FILE EMPTY");
                return 0;

            }
            else
            {
                foreach (string dataRead in data)
                {
                    SendDataToReceiverViaConsole(dataRead);
                    Thread.Sleep(1000);

                }

                return 1;
            }
        }
    }
}
