using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.MyControllers;

namespace PersonsBaseTests4.MyControllers
{
    [TestClass()]
    public class SaverJSonTests
    {
        public class Forecast
        {
            public DateTime Date;
            public int TemperatureC;
            public string Summary;
            private string privField = "PrivateFi";
            private string _pf = "223321";

            public string Pf
            {
                get { return _pf; }
                set { _pf = value; }
            }
        }


        [TestMethod()]
        public void SaveTest_1()
        {
            // Test 1
            var fc = new Forecast()
            {
                Date = DateTime.Parse("01.02.2021"),
                Summary = "Summary Text",
                TemperatureC = 123
            };

            SaverJSon sjs = new SaverJSon();
            // Action
            sjs.Save(fc, "Forecast.json");
            var actual = sjs.Load<Forecast>("Forecast.json");
            // Assert
            Assert.AreEqual(fc.Date.CompareTo(actual.Date), 0);
            Assert.IsTrue(fc.Summary.Equals(actual.Summary));
            Assert.AreEqual(fc.TemperatureC, actual.TemperatureC);
            Assert.IsTrue(fc.Pf.Equals("223321"));
        }

        public class Forecast2
        {
            [JsonInclude]
            public DateTime Date;
            [JsonInclude]
            public int TemperatureC;
            [JsonInclude]
            public string Summary { get; } = "Summary Text2";

            public string Get()
            {
                return Summary;
            }
        }

        [TestMethod()]
        public void SaveTest_2()
        {
            // Test 1
            var fc = new Forecast2()
            {
                Date = DateTime.Parse("01.02.2022"),
                // Summary = "Summary Text",
                TemperatureC = 5123
            };

            SaverJSon sjs = new SaverJSon();
            // Action
            sjs.Save(fc, "Forecast2.json");
            var actual = sjs.Load<Forecast>("Forecast2.json");
            // Assert
            Assert.AreEqual(fc.Date.CompareTo(actual.Date), 0);
            Assert.IsTrue(fc.Get().Equals(actual.Summary));
            Assert.AreEqual(fc.TemperatureC, actual.TemperatureC);

        }

        /// <summary>
        ///  Сложный класс с конструкторами
        /// </summary>

        public class WeatherForecastComplex
        {
            public readonly string ROnlyField = "ReadOnly Text";
            public DateTime Date { get; set; }
            [JsonInclude]
            public int IdPerson { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            [JsonInclude]
            public string SummaryField;
            public IList<DateTime> DatesAvailable { get; set; }
            [JsonInclude]
            public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
            public string[] SummaryWords { get; set; }
            public HighLowTemps hLow = null;
            public MyEnum EeEnum = MyEnum.Wendsday;
            public WeatherForecastComplex(string summary)
            {
                Summary = summary;
                Date = DateTime.Parse("01.02.2022");
                TemperatureCelsius = 555;
                SummaryField = "summaryField";
                DatesAvailable = new List<DateTime>() { DateTime.Parse("22.02.2022"), DateTime.Parse("22.02.2022") };
                TemperatureRanges = new Dictionary<string, HighLowTemps>() { { "k1", new HighLowTemps() }, { "k2", new HighLowTemps(333, 555) } };
                SummaryWords = new[] { "q2" };
                IdPerson = 777;
            }
        }
        public enum MyEnum
        {
            Monday,
            Twuesday,
            Wendsday
        }
        public class HighLowTemps
        {
            public int High { get; set; }
            public int Low { get; set; }

            public HighLowTemps(int a, int b)
            {
                High = a;
                Low = b;
            }
            public HighLowTemps()
            {
                High = 1111;
                Low = 2222;
            }
        }

        [TestMethod()]
        public void SaveTest_3()
        {
            // Test 1
            var fc = new WeatherForecastComplex("SomeText")
            {
                Date = DateTime.Parse("01.09.2022"),
            };

            SaverJSon sjs = new SaverJSon();
            // Action
            sjs.Save(fc, "Forecast3.json");
            var actual = sjs.Load<WeatherForecastComplex>("Forecast3.json");
            // Assert
            Assert.AreEqual(fc.Date.CompareTo(actual.Date), 0);
            Assert.IsTrue(fc.Summary.Equals(actual.Summary));
            Assert.IsTrue(fc.SummaryField.Equals(actual.SummaryField));
            Assert.AreEqual(fc.SummaryWords[0], actual.SummaryWords[0]);
            Assert.IsNull(actual.hLow);
            Assert.AreEqual(fc.DatesAvailable.Count, actual.DatesAvailable.Count);
            Assert.IsTrue(fc.ROnlyField.Equals(actual.ROnlyField));
            Assert.AreEqual("Wendsday", actual.EeEnum.ToString());
        }


    }
}