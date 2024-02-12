using OrionCalcShared.DataObjects;
using OrionCalcShared.Enums;

namespace OrionCalcApi.BLL
{
    public interface ISubtractMathService
    {
        MathResult SubtractItems(SubmittedItems items);
    }
    public class SubtractMathService : MathService, ISubtractMathService
    {

        public MathResult SubtractItems(SubmittedItems items)
        {
            try
            {
                var passedGenericTest = ProcessAndErrorCheckValues(items);
                if (!passedGenericTest)
                {
                    //bail with prepopulated error message
                    return mathResult;
                }
                var mathFunc = DoSubtract;
                DoMath(mathFunc);
            }
            catch (Exception)
            {
                mathResult.Message = "Uncaught error in the Subtract function.";
                mathResult.IsSuccess = false;
            }


            return mathResult;
        }

        public decimal DoSubtract(decimal dec1, decimal dec2) { 
            return dec1 - dec2;
        }


    }
}
