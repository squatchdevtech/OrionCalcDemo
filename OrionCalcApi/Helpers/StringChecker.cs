using System.Collections;

namespace OrionCalcApi.Helpers
{
    public class StringChecker
    {
        /*
         * Converts all string to decimals where possible.
         * Implicitly this means if the number of decimals returned is less then the number of strings that went in, not all values could be converted
         */
        public static ArrayList ConvertToDecimal(string[] values)
        {
            var decimals = new ArrayList();
            decimal newDecimal = 0;
            foreach (var str in values) { 
                if(!String.IsNullOrWhiteSpace(str))
                {
                    bool isDecimal = decimal.TryParse(str, out newDecimal);
                    if (isDecimal)
                    {
                        decimals.Add(newDecimal);
                    }
                }

            }

            return decimals;
        }
    }
}
