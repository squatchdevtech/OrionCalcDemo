using OrionCalcShared.DataObjects;

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

                DoMath("-");
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
