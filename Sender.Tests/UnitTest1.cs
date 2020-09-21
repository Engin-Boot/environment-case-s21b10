
using Xunit;
using System.IO;


namespace Sender.Tests
{
    public class SenderTests
    {
        //string EmptyTestDataPath = @"D:\C#\EnvironmentCaseStudy\Sender\bin\Debug\EmptyTestData.csv";
        //string NonEmptyTestDataPath = @"D:\C#\EnvironmentCaseStudy\Sender\bin\Debug\TemperatureAndHumidityData.csv";
        //string NonEmptyTestDataPathWithoutHeaders = @"D:\C#\EnvironmentCaseStudy\Sender\bin\Debug\TemperatureHumidityDataWithoutHeader.csv";
        string EmptyTestDataPath = @"D:\a\environment-case-s21b10\environment-case-s21b10\EmptyTestData.csv";
        string NonEmptyTestDataPath = @"D:\a\environment-case-s21b10\environment-case-s21b10\TemperatureAndHumidityData.csv";
        string NonEmptyTestDataPathWithoutHeaders = @"D:\a\environment-case-s21b10\environment-case-s21b10\TemperatureHumidityDataWithoutHeader.csv";


        readonly FileReader _read = new FileReader();
        [Fact]
        public void TestWhenFileExistsAtPath()
        {
            var data = _read.CheckFileExists(NonEmptyTestDataPath);
            Assert.True(data != null);

        }
        [Fact]
        public void TestWhenFileDoesNotExistsAtPath()
        {
            
            var data = _read.CheckFileExists(@"dummy\path\TestData.csv");
            Assert.True(data == null);

        }
        [Fact]
        public void TestWhenFileEmpty()
        {
            var data = _read.CheckFileExists(EmptyTestDataPath);
            Assert.True(data.Count == 0);

        }
        [Fact]
        public void TestWhenFileIsNotEmpty()
        {
            var data = _read.CheckFileExists(NonEmptyTestDataPath);
            Assert.True(data.Count > 0);

        }
        [Fact]
        public void TestWhenFileHasNoHeaders()
        {
            TextReader sr = new StreamReader(NonEmptyTestDataPathWithoutHeaders);
            Assert.False(_read.CheckHeader(sr.ReadLine()));
            
            var data = _read.CheckFileExists(NonEmptyTestDataPathWithoutHeaders);

            Assert.True(data.Count > 0);
            sr.Dispose();
        }
        [Fact]
        public void WhenDataSenderCalledStringIsPrintedOnConsole()
        {
            DataSenderViaConsole sendData=new DataSenderViaConsole();
            string dataToBeSend = "89,78";
            string data=sendData.SendDataToReceiverViaConsole(dataToBeSend);
            Assert.Equal(data,dataToBeSend);
        }


    }
}
