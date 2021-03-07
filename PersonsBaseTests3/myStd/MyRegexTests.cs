using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.myStd;

namespace PersonsBase.myStd.Tests
{
    [TestClass()]
    public class MyRegexTests
    {
    
        [TestMethod()]
        public void FormatPhoneTest()
        {

            string a = "+7(912) 407 - 1 - 9-6-0";
            string expected = "8(912) 407-19-60";
            var actual = MyRegex.FormatPhone(a);
            Assert.AreEqual(expected, actual);

            actual = MyRegex.FormatPhone(expected);
            Assert.AreEqual(expected, actual);

            string value1 = "9124071960";
            actual = MyRegex.FormatPhone(value1);
            Assert.AreEqual(expected, actual);

            string value2 = "+79124071960";
            actual = MyRegex.FormatPhone(value2);
            Assert.AreEqual(expected, actual);

            string value3 = "8 912407 1960";
            actual = MyRegex.FormatPhone(value3);
            Assert.AreEqual(expected, actual);

            string value4 = "79124071960";
            actual = MyRegex.FormatPhone(value4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPhoneDigitsTest()
        {
            string a = "+7(912) 407 - 1 - 9-6-0";
            string expected = "89124071960";

            var actual = MyRegex.GetPhoneDigits(a);
            Assert.AreEqual(expected, actual);


            string value1 = "9124071960";
            actual = MyRegex.GetPhoneDigits(value1);
            Assert.AreEqual(expected, actual);

            string value2 = "+79124071960";
            actual = MyRegex.GetPhoneDigits(value2);
            Assert.AreEqual(expected, actual);

            string value3 = "8 912407 1960";
            actual = MyRegex.GetPhoneDigits(value3);
            Assert.AreEqual(expected, actual);

            string value4 = "79124071960";
            actual = MyRegex.GetPhoneDigits(value4);
            Assert.AreEqual(expected, actual);
        }
    }
}

namespace PersonsBaseTests3.myStd
{
    [TestClass()]
    public class MyRegexTests
    {
        [TestMethod()]
        public void CompactSpacesTest()
        {
            string str = "aa     bbb сс  вв";

            // Считаем пробелы в оригинальной строке
            Regex regex = new Regex(" ");
            MatchCollection matches = regex.Matches(str);
            var numSpaces = matches.Count;
            Assert.AreEqual(8, numSpaces);

            // Считаем пробелы в уплотненной строке
            var actualString = MyRegex.CompactSpaces(str);
            matches = regex.Matches(actualString);
            numSpaces = matches.Count;
            Assert.AreEqual(3, numSpaces);
        }
    }
}