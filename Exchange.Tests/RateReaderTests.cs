using NUnit.Framework;
using Exchange;

namespace Exchange.Tests
{
    public class RateReaderTests
    {
        [Test]
        public void RateReaderHardcodedCurrencyRatesResult()
        {
            RateReader rateReader = new RateReader();

            Assert.IsTrue(rateReader.CurrencyRates["NOK"] == 78.40);
        }
    }
}
