using System;
using Xunit;

namespace Receiver.Tests
{
    public class UnitTest1
    {
        internal EnvironmentalCondition SystemTemp = new EnvironmentalCondition(0, 40, 4, 37, "Temperature");
        internal EnvironmentalCondition SystemRelHumidity = new EnvironmentalCondition(0, 90, 0, 70, "Humidity");
        [Fact]
        public void WhenEnvironmentConditionsAreInRange()
        {
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            SystemTemp.ParameterValue = "28";
            SystemRelHumidity.ParameterValue = "55";
            SystemTemp.Analyse(alertDelObj);
            Assert.False(SystemTemp.IsError(alertDelObj));
            Assert.False(SystemTemp.IsWarning(alertDelObj));
            Assert.False(SystemRelHumidity.IsError(alertDelObj));
            Assert.False(SystemRelHumidity.IsWarning(alertDelObj));
        }
        [Fact]
        public void WhenTemperatureConditionsBreachWarningRange()
        {
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            SystemTemp.ParameterValue = "38.5";
            Assert.True(SystemTemp.IsWarning(alertDelObj));
            SystemTemp.ParameterValue = "2";
            Assert.True(SystemTemp.IsWarning(alertDelObj));
            //systemTemp.Analyse(alertDelObj);


        }
        [Fact]
        public void WhenHumidityConditionBreachWarningRange()
        {
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            SystemRelHumidity.ParameterValue = "75";
            Assert.True(SystemRelHumidity.IsWarning(alertDelObj));
        }
        [Fact]
        public void WhenEnvironmentConditionsBreachErrorLevels()
        {
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            SystemTemp.ParameterValue = "-1";
            Assert.True(SystemTemp.IsError(alertDelObj));
            SystemRelHumidity.ParameterValue = "92.8";
            Assert.True(SystemRelHumidity.IsError(alertDelObj));
            SystemTemp.ParameterValue = "42";
            Assert.True(SystemTemp.IsError(alertDelObj));
            // systemTemp.Analyse(alertDelObj);


        }
        [Fact]
        public void WhenInvalidDataReceived()
        {
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            SystemTemp.ParameterValue = "45*";
            SystemRelHumidity.ParameterValue = "2.1e310";
            Assert.True(SystemTemp.Analyse(alertDelObj) == 0);
            //Assert.True(SystemRelHumidity.Analyse(alertDelObj) == 0);

        }

        [Fact]
        public void WhenEmptyDataReceived()
        {

            Analyzer analyzeObj = new Analyzer();
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            string receiveddata = ",";
            //string[] seperatedData = receiveddata.Split(',', StringSplitOptions.RemoveEmptyEntries) ;
            int getStatus = analyzeObj.DataInterpretation(receiveddata, alertDelObj);
            Assert.True(getStatus == 0);

        }
        [Fact]
        public void WhenNonEmptyDataReceived()
        {

            Analyzer analyzeObj = new Analyzer();
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            string receiveddata = "89,45";
            //string[] seperatedData = receiveddata.Split(',', StringSplitOptions.RemoveEmptyEntries) ;
            int getStatus = analyzeObj.DataInterpretation(receiveddata, alertDelObj);
            Assert.True(getStatus == 1);

        }

        [Theory]
        [InlineData("50,50", 1)]
        [InlineData("", 0)]
        [InlineData(",", 0)]
        [InlineData("20,30,40", 1)]
        public void WhenNonEmptyDataReceivedThenDataInterpretationReturnsOne(string data, int expected)
        {
            Analyzer analyzeObj = new Analyzer();
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            int actual = analyzeObj.DataInterpretation(data, alertDelObj);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("parameter","message","value","parameter message value")]
        public void WhenAlertDelegateInvokedThenStringIsPrinted(string parameter, string message, string value, string expected)
        {
            
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            string actual = alertDelObj(parameter,message,value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2.1e311")]
        public void WhenDataIsInvalidThenIsDataValidReturnsFalse(string input)
        {
            Analyzer analyzeObj = new Analyzer();
            ConsoleAlerter alerter = new ConsoleAlerter();
            AlertDelegate alertDelObj = alerter.SendAlert;
            SystemTemp.ParameterValue = input;
            bool actual = SystemTemp.IsDataValid();
            Assert.False(actual);

        }

        [Fact]
        public void WhenMainIsWorking()
        {
            Program obj = new Program();
            

        }


    }

}

