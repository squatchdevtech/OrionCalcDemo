using System.Collections;

namespace OrionCalcShared.DataObjects
{
    public class MathResult
    {
        public decimal FinalValue { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public ArrayList Values { get; set; }
    }
}
