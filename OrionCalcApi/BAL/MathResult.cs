using Microsoft.VisualBasic;
using System.Collections;

namespace OrionCalcApi.BAL
{
    public class MathResult
    {
        public decimal FinalValue { get; set; }
        public string? Message{ get; set; }
        public bool IsSuccess { get;set; }
        public ArrayList Values { get; set; }


    }
}
