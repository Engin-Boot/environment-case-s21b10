using System;

namespace Receiver
{
    public class Analyzer
    {
        internal EnvironmentalCondition SystemTemp = new EnvironmentalCondition(0, 40, 4, 37, "Temperature");
        internal EnvironmentalCondition SystemRelHumidity = new EnvironmentalCondition(0, 90, 0, 70, "Humidity");


        public int DataInterpretation(string inputData, AlertDelegate alertObj)
        {
            char[] separator = new char[] { ',' };
            string[] separatedData = inputData.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (separatedData.Length != 0)
            {
                SystemTemp.ParameterValue = separatedData[0];
                SystemRelHumidity.ParameterValue = separatedData[1];
                SystemTemp.Analyse(alertObj);
                SystemRelHumidity.Analyse(alertObj);
                return 1;
            }
            else
            {
                //Console.WriteLine(separatedData);
                alertObj("", "No input Data", "");
                return 0;
            }
        }
    }
    public class EnvironmentalCondition
    {
        private double _errorUpperBound;
        private double _errorLowerBound;
        private double _warningUpperBound;
        private double _warningLowerBound;
        private string _parameterValue;
        private string _name;

        #region Properties
        public double Error_upperBound { get { return _errorUpperBound; } set { _errorUpperBound = value; } }
        public double Error_lowerBound { get { return _errorLowerBound; } set { _errorLowerBound = value; } }
        public double Warning_upperBound { get { return _warningUpperBound; } set { _warningUpperBound = value; } }
        public double Warning_lowerBound { get { return _warningLowerBound; } set { _warningLowerBound = value; } }
        public string ParameterValue { get { return _parameterValue; } set { _parameterValue = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        #endregion 
        public EnvironmentalCondition(double errorLow, double errorHigh, double warnLow, double warnHigh, string name)
        {
            this.Error_lowerBound = errorLow;
            this.Error_upperBound = errorHigh;
            this.Warning_lowerBound = warnLow;
            this.Warning_upperBound = warnHigh;
            this.Name = name;
        }

        public int Analyse(AlertDelegate alertObj)
        {
            if (!this.IsDataValid())
            {
                //alert about invalid data;
                alertObj($"{this.Name}", " - Invalid Data with value ", $"{this.ParameterValue}");
                //Console.WriteLine("Invalid Data");
                return 0;
            }
            else
            {
                this.CheckErrorOrWarning(alertObj);
                return 1;

            }
        }
        public bool IsDataValid()
        {
            bool status = true;
            try
            {
                Convert.ToDouble(this.ParameterValue);
            }
            catch (FormatException)
            {
                //Console.WriteLine("Format Exception");
                status = false;
            }
            catch (OverflowException)
            {
                //Console.WriteLine("Overflow Exception");
                status = false;
            }
            //Console.WriteLine($"{status}");
            return status;
        }
        public void CheckErrorOrWarning(AlertDelegate alertObj)
        {
            if (!this.IsError(alertObj))
            {
                if (!this.IsWarning(alertObj))
                {
                    alertObj($"{this.Name}", "is at the ideal condition with value ", $"{ this.ParameterValue}");
                }
            }
        }
        public bool IsError(AlertDelegate alertObj)
        {
            if (Convert.ToDouble(this.ParameterValue) < this.Error_lowerBound)
            {
                alertObj($"{this.Name}", "is LOWER than the ideal condition : ERROR with value ", $"{this.ParameterValue }");
                return true;
            }
            if (Convert.ToDouble(this.ParameterValue) > this.Error_upperBound)
            {
                //generate alert;
                alertObj($"{this.Name}", "is HIGHER than the ideal condition : ERROR with value ", $"{ this.ParameterValue}");
                //Console.WriteLine($"ERROR : {this.Name} is HIGHER than the ideal condition");
                return true;
            }
            return false;

        }
        public bool IsWarning(AlertDelegate alertObj)
        {
            if (Convert.ToDouble(this.ParameterValue) < this.Warning_lowerBound)
            {
                //generate alert;
                alertObj($"{this.Name}", "may get LOWER than the ideal condition : WARNING with value ", $"{ this.ParameterValue}");
                //Console.WriteLine($"WARNING : {this.Name} may soon be LOWER than the ideal condition");
                return true;
            }
            if (Convert.ToDouble(this.ParameterValue) > this.Warning_upperBound)
            {
                //generate alert;
                alertObj($"{this.Name}", "may get HIGHER than the ideal condition : WARNING with value ", $"{ this.ParameterValue}");
                //Console.WriteLine($"WARNING : {this.Name} may soon be HIGHER than the ideal condition");
                return true;
            }

            return false;
        }


    }

}



