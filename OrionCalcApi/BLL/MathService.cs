using OrionCalcApi.Helpers;
using OrionCalcShared.DataObjects;
using OrionCalcShared.Enums;
using System.Collections;

namespace OrionCalcApi.BLL
{
    public interface IMathService
    {
        bool ProcessAndErrorCheckValues(SubmittedItems items);
        void DoMath(CommonTypes.MathFunction mathFunction);

    }
    public class MathService : IMathService
    {
        protected MathResult mathResult { get; set; }
        private int DigitLimit { get; set; }

        public MathService()
        {
            mathResult = new MathResult();
            DigitLimit = 5;
        }

        public bool ProcessAndErrorCheckValues(SubmittedItems items)
        {
            if(items.numbers.Length <= 1)
            {
                NotEnoughNumbers();
                return false;
            }
            if(items.numbers.Length > DigitLimit) {
                TooManyNumbers();
                return false;
            }
            mathResult.Values = StringChecker.ConvertToDecimal(items.numbers);
            //check to make sure all converted.
            //TODO: find a better path
            if(items.numbers.Length != mathResult.Values.Count)
            {
                UnableToConvertAllStrings();
                return false;
            }
            return true;
        }

        public void DoMath(CommonTypes.MathFunction mathFunction)
        {
            decimal finalValue = (decimal)mathResult.Values[0];
            decimal lastValue = 0;
            try
            {
                for(int i = 1; i < mathResult.Values.Count; i++)
                {
                    lastValue = (decimal)mathResult.Values[i];
                    finalValue = ExecuteMath(finalValue, lastValue, mathFunction);
                }

                mathResult.FinalValue = finalValue;
                mathResult.IsSuccess = true;
            } 
            catch (OverflowException)
            {
                mathResult.Message = String.Format("The result of the equation exceeded the bounds of the decimal parameter. {0} + {1} failed.", finalValue, lastValue);
                mathResult.IsSuccess = false;
            }
            catch (DivideByZeroException)
            {
                mathResult.Message = String.Format("There was an attempt to divided by zero. This is not possible.");
                mathResult.IsSuccess = false;
            }
        }

        protected decimal ExecuteMath(decimal result, decimal secondVal, CommonTypes.MathFunction action)
        {
            switch (action) {
                case CommonTypes.MathFunction.Add:
                    result += secondVal;
                    break;
                case CommonTypes.MathFunction.Subtract:
                    result -= secondVal;
                    break;
                case CommonTypes.MathFunction.Divide:
                    result /= secondVal;
                    break;
                case CommonTypes.MathFunction.Multiply:
                    result *= secondVal;
                    break;
            }
            return result;
        }

        protected void NotEnoughNumbers()
        {
            mathResult.Message = "Not enough numbers submitted.";
            mathResult.IsSuccess = false;
        }


        protected void TooManyNumbers()
        {
            mathResult.Message = "Too many numbers submitted.";
            mathResult.IsSuccess = false;
        }

        protected void UnableToConvertAllStrings()
        {
            mathResult.Message = "Unable to convert all the submitted values to a decimal value";
            mathResult.IsSuccess = false;
        }

        
    }
}
