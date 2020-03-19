using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseConversion;

namespace BaseConversionTests
{
    [TestClass]
    public class UnitTestBaseConvert
    {
        [TestMethod]
        public void TestFrom10Unsigned() {

            int[] bases = {2, 8, 10, 16};

            foreach (var b in bases) {
                for (int j = 0; j < 100; j++) {

                    string s = Convert.ToString(j, b);

                    string myConversion = BaseConvert.From10Unsigned(j, b);
                    Assert.AreEqual(myConversion, s);
                }
            }
            Assert.ThrowsException<ArgumentException>(() => BaseConvert.From10Unsigned(-1000, 2));
            Assert.ThrowsException<ArgumentException>(() => BaseConvert.From10Unsigned(-1000, -2));
            Assert.ThrowsException<ArgumentException>(() => BaseConvert.From10Unsigned(1000, -2));
            Assert.ThrowsException<ArgumentException>(() => BaseConvert.From10Unsigned(1000, 1));
            Assert.ThrowsException<ArgumentException>(() => BaseConvert.From10Unsigned(0, 1));
            Assert.ThrowsException<ArgumentException>(() => BaseConvert.From10Unsigned(1, 0));
        }

        [TestMethod]
        public void TestValidate() {
            PrivateType type = new PrivateType(typeof(BaseConvert));

            for (int i = 0; i < 10; i++) {
                Assert.AreEqual(i.ToString()[0], type.InvokeStatic("Validate", i));
            }

            for (int i = 10; i < 36; i++) {
                Assert.AreEqual((char)(i + 87), type.InvokeStatic("Validate", i));
            }
        }

        [TestMethod]
        public void TestDevalidate()
        {
            PrivateType type = new PrivateType(typeof(BaseConvert));

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, type.InvokeStatic("Devalidate", i.ToString()[0]));
            }

            for (char i = 'a'; i < 'z'; i++)
            {
                Assert.AreEqual(i - 87, type.InvokeStatic("Devalidate", i));
            }
        }

        [TestMethod]
        public void TestReverseString()
        {
            PrivateType type = new PrivateType(typeof(BaseConvert));
            Random r = new Random();
            
            for (int randomIndex = 0; randomIndex < 10; randomIndex++) {        //50 times random string test

                string str = string.Empty;     //Test string
                for (int i = 0; i < 50; i++) str += (char)r.Next(33, 127);

                char[] chars = str.ToCharArray();
                for (int i = 0, j = str.Length - 1; i < j; i++, j--)
                {
                    char c = chars[i];
                    chars[i] = chars[j];
                    chars[j] = c;
                }
                Assert.AreEqual(new string(chars), type.InvokeStatic("ReverseString", str));
            }

            
        }

    }
}
