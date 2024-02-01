using OrionCalcShared.DataObjects;

namespace OrionCalcApi.BLL
{
    public interface IAddMathService
    {
        MathResult AddItems(SubmittedItems items);
        void DoAddition();
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

                //DoAddition();
                DoMath("+");
                
            } catch (Exception)
            {
                mathResult.Message = "Uncaught error in the Add function.";
                mathResult.IsSuccess = false;
            }
            

            return mathResult;
        }

        public void DoAddition()
        {
            decimal finalValue = 0;
            decimal lastValue = 0;
            try
            {
                foreach (var dec in mathResult.Values)
                {
                    lastValue = (decimal)dec;
                    finalValue += lastValue;
                }

                mathResult.FinalValue = finalValue;
                mathResult.IsSuccess = true;
            } catch(OverflowException)
            {
                mathResult.Message = String.Format("The result of the equation exceeded the bounds of the decimal parameter. {0} + {1} failed.",finalValue,lastValue);
                mathResult.IsSuccess = false;
            } 
        }
    }
}
