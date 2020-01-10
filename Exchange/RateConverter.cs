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

            bool bothCurrenciesAreDanish = (mainCurrency == "DKK") && (moneyCurrency == "DKK");

            if (bothCurrenciesAreDanish)
            {
                rateForSpecifiedCurrencies = 1.0;
            }
            else
            {

                if (!currencyRates.ContainsKey(moneyCurrency) && moneyCurrency != "DKK")
                {
                    throw new ArgumentException("Specified currencies not found in provided rates");
                }

                if (!currencyRates.ContainsKey(mainCurrency) && mainCurrency != "DKK")
                {
                    throw new ArgumentException("Specified currencies not found in provided rates");
                }

                if (mainCurrency == "DKK")
                {
                    rateForSpecifiedCurrencies = 100 / currencyRates[moneyCurrency];
                }
                else
                {
                    if (moneyCurrency == "DKK")
                    {
                        rateForSpecifiedCurrencies = currencyRates[mainCurrency] / 100;
                    }
                    else
                    {
                        rateForSpecifiedCurrencies = currencyRates[mainCurrency] / currencyRates[moneyCurrency];
                    }
                }
            }

            double calculateAmountOfMoney = rateForSpecifiedCurrencies * amountOfMoney;

            return Math.Round (calculateAmountOfMoney, 4);
        }
    }
}
