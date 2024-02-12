namespace OrionCalcShared.DataObjects
{
    public class SubmittedItems
    {
        public string[]? numbers { get; set; }
        public string? baseNumberSystem { get; set; }

        public SubmittedItems() { }
        public SubmittedItems(string[] _numbers) {
            numbers = _numbers;
        }
    }
}