using OrionCalcShared.DataObjects;
using OrionCalcShared.Enums;

namespace OrionCalcApi.BLL
{
    public interface IDivideMathService
    {
        MathResult DivideItems(SubmittedItems items);
    }

    public class DivideMathService: MathService, IDivideMathService
    {
        public MathResult DivideItems(SubmittedItems items)
        {
            try
            {
                var passedGenericTest = ProcessAndErrorCheckValues(items);
                if (!passedGenericTest)
                {
                    //bail with prepopulated error message
                    return mathResult;
                }
                //TODO: currently overkill since i check for the divide by zero exception
                if (CheckForDivideByZero())
                {
                    mathResult.Message = "Divide by zero error will happen.";
                    mathResult.IsSuccess = false;
                    return mathResult;
                }
                var mathFunc = DoDivision;
                DoMath(mathFunc);


            }
            catch (Exception)
            {
                mathResult.Message = "Uncaught error in the Subtract function.";
                mathResult.IsSuccess = false;
            }


            return mathResult;
        }

        public decimal DoDivision(decimal dec1, decimal dec2)
        {
            return dec1/dec2;
        }

        /*
         * return true if there is a divide by zero error going to happen
         */
        private bool CheckForDivideByZero()
        {
            if (mathResult.Values.Contains(0))
            {
                var lastIndexOfZero = 0;
                var counter = 0;

                foreach (var item in mathResult.Values)
                {
                    if ((decimal)item == 0)
                    {
                        lastIndexOfZero = counter;
                        break;
                    }
                    counter++;
                }
                return (lastIndexOfZero > 0) ? true : false;
            }
            else
            {
                return false;
            }

        }

    }
}
