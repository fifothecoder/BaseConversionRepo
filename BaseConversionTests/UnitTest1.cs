using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseConversion;

namespace BaseConversionTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConversionsGood() {

            int[] bases = {2, 8, 10, 16};

            foreach (var b in bases) {
                for (int j = 0; j < 100; j++) {

                    string s = Convert.ToString(j, b);

                    string myConversion = BaseConvert.From10Unsigned(j, b);
                    Assert.AreEqual(myConversion, s);
                    
                }
            }

        }
    }
}
