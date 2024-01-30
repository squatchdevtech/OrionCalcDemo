using OrionCalcApi.BAL;

namespace OrionCalcApi.BLL
{
    public interface IMultiplyMathService
    {
        MathResult MultiplyItems(SubmittedItems items);
    }
    public class MultiplyMathService: MathService, IMultiplyMathService
    {
        public MathResult MultiplyItems(SubmittedItems items)
        {
            try
            {
                var passedGenericTest = ProcessAndErrorCheckValues(items);
                if (!passedGenericTest)
                {
                    //bail with prepopulated error message
                    return mathResult;
                }

                DoMath("*");
            }
            catch (Exception)
            {
                mathResult.Message = "Uncaught error in the Subtract function.";
                mathResult.IsSuccess = false;
            }

            return mathResult;
        }
    }
}
