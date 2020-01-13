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
            if (!currencyRates.ContainsKey(moneyCurrency) && moneyCurrency != "DKK")
            {
                throw new ArgumentException("Specified currencies not found in provided rates");
            }

            if (!currencyRates.ContainsKey(mainCurrency) && mainCurrency != "DKK")
            {
                throw new ArgumentException("Specified currencies not found in provided rates");
            }

            double mainRate = mainCurrency == "DKK" ? 100 : currencyRates[mainCurrency];

            double moneyRate = moneyCurrency == "DKK" ? 100 : currencyRates[moneyCurrency];

            double rateForSpecifiedCurrencies = mainRate / moneyRate;

            double calculateAmountOfMoney = rateForSpecifiedCurrencies * amountOfMoney;

            return Math.Round (calculateAmountOfMoney, 4);
        }
    }
}
