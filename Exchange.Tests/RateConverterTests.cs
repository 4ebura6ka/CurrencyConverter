using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Exchange.Tests
{
    public class RateConverterTests
    {
        private Dictionary<string, double> HardcodedCurrencyRates => new Dictionary<string, double>
        {
            {"EUR", 743.94 },
            {"USD", 663.11 },
            {"GBP", 852.85 },
            {"SEK", 76.10 },
            {"NOK", 78.40 },
            {"CHF", 683.58 },
            {"JPY", 5.9740 }
        };

        [Test]
        public void ConvertResult()
        {
            RateConverter rateConverter = new RateConverter(HardcodedCurrencyRates);

            Assert.AreEqual(1120.6965, rateConverter.Convert("GBP", "SEK", 100));
        }

        [Test]
        public void ConvertDKKResult()
        {
            RateConverter rateConverter = new RateConverter(HardcodedCurrencyRates);

            Assert.AreEqual(7.4394, rateConverter.Convert("EUR", "DKK", 1));
        }
    }
}
