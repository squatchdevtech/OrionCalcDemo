using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionCalcTests
{
    [TestClass]
    public class OrionCalcApiHelperTests
    {
        [TestMethod]
        public void ConvertToDecimalTest()
        {
            decimal expected = (decimal)1.34444;
            var values = OrionCalcApi.Helpers.StringChecker.ConvertToDecimal(["1.34444"]);

            Assert.AreEqual(expected, values[0]);
        }
    }
}
