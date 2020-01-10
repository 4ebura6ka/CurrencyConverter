using System;
using System.Collections.Generic;

namespace Exchange
{
    public class RateConverter
    {
        private Dictionary<string, double> currencyRates;

        public RateConverter(Dictionary<string, double> currencyRates)
        {
            this.currencyRates = currencyRates;
        }

        public double Convert(string mainCurrency, string moneyCurrency, double amountOfMoney)
        {
            if (!currencyRates.ContainsKey(mainCurrency) || !currencyRates.ContainsKey(moneyCurrency))
            {
                throw new ArgumentException("Specified currencies not found in provided rates");
            }

            double rateForSpecifiedCurrencies = currencyRates[mainCurrency] / currencyRates[moneyCurrency];

            return rateForSpecifiedCurrencies * amountOfMoney;
        }
    }
}
