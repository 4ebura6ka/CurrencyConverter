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
            double rateForSpecifiedCurrencies;

            if (!currencyRates.ContainsKey(moneyCurrency))
            {
                throw new ArgumentException("Specified currencies not found in provided rates");
            }

            if (mainCurrency == "DKK")
            {
                rateForSpecifiedCurrencies = 100 / currencyRates[moneyCurrency];
            }
            else if (moneyCurrency == "DKK")
            {
                rateForSpecifiedCurrencies = currencyRates[moneyCurrency] / 100;
            }
            else
            {
                if (!currencyRates.ContainsKey(mainCurrency))
                {
                    throw new ArgumentException("Specified currencies not found in provided rates");
                }

                rateForSpecifiedCurrencies = currencyRates[mainCurrency] / currencyRates[moneyCurrency];
            }

            double calculateAmountOfMoney = rateForSpecifiedCurrencies * amountOfMoney;

            return Math.Round (calculateAmountOfMoney, 4);
        }
    }
}
