using OrionCalcShared.DataObjects;
using OrionCalcShared.Enums;

namespace OrionCalcApi.BLL
{
    public interface IAddMathService
    {
        MathResult AddItems(SubmittedItems items);
    }
    public class AddMathService : MathService, IAddMathService
    {
        public MathResult AddItems(SubmittedItems items)
        {
            try
            {
                var passedGenericTest = ProcessAndErrorCheckValues(items);
                if(!passedGenericTest) {
                    //bail with prepopulated error message
                    return mathResult;
                }

                var mathFunc = DoAdd;

                //DoAddition();
                DoMath(mathFunc);
                
            } catch (Exception)
            {
                mathResult.Message = "Uncaught error in the Add function.";
                mathResult.IsSuccess = false;
            }
            

            return mathResult;
        }

        public decimal DoAdd(decimal dec1, decimal dec2)
        {
            return dec1 + dec2;
        }
    }
}
