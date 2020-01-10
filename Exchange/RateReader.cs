using System;
using System.Collections.Generic;

namespace Exchange
{
    public class RateReader
    {
        public string FileRatePath { get; set; }

        public Dictionary<string, double> CurrencyRates { get; private set; }

        private Dictionary<string, double> HardcodedCurrencyRates => new Dictionary<string, double>
        {
            {"EUR", 743.94 },
            {"USD", 663.11 },
            {"GBP", 852.85 },
            {"SEK", 76.10 },
            {"NOK", 78.40 },
            {"CHF", 683.58 },
            {"JPY", 5.9740 }
        } ;

        public RateReader()
        {
            if (FileRatePath == string.Empty || FileRatePath == null)
            {
                CurrencyRates = HardcodedCurrencyRates;
            }
        }
    }
}
