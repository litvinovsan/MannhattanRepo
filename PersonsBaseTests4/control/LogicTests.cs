using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.control;

namespace PersonsBaseTests4.control
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void NormalizeBarCodeNumber_UpTo13_Test()
        {
            string s1_13 = "0000000002387";
            string s2_12 = "000000000711";
            string s3_11 = "00000000010";
            int expectedLen = 13;

            var actual = Logic.NormalizeBarCodeNumber(s1_13);
            Assert.AreEqual(expectedLen, actual.Length);
            Assert.AreEqual("0000000002387", actual);

            actual = Logic.NormalizeBarCodeNumber(s2_12);
            Assert.AreEqual(expectedLen, actual.Length);
            Assert.AreEqual("0000000000711", actual);


            actual = Logic.NormalizeBarCodeNumber(s3_11);
            Assert.AreEqual(expectedLen, actual.Length);
            Assert.AreEqual("0000000000010", actual);

            actual = Logic.NormalizeBarCodeNumber("0000000000000");
            Assert.AreEqual(0, actual.Length);
            Assert.AreEqual("", actual);
        }

        [TestMethod()]
        public void NormalizeBarCodeNumber_Null_Test()
        {
            string s1 = null;
            var actual = Logic.NormalizeBarCodeNumber(s1);

            Assert.AreEqual(actual, string.Empty);
        }

        [TestMethod()]
        public void NormalizeBarCodeNumber_DownTo13_Test()
        {
            string s1_15 = "000000000002387";
            string s2_16 = "1000000002387000";

            int expectedLen = 13;

            var actual = Logic.NormalizeBarCodeNumber(s1_15);
            Assert.AreEqual(expectedLen, actual.Length);
            Assert.AreEqual("0000000002387", actual);

            actual = Logic.NormalizeBarCodeNumber(s2_16);
            Assert.AreEqual(expectedLen, actual.Length);
            Assert.AreEqual("1000000002387", actual);
        }
    }
}