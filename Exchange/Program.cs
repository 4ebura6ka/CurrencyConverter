using System;

namespace Exchange
{
    class MainClass
    { 
        public static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Usage: Exchange <currency pair> <amount to exchange>");
            }

            RateReader rateReader = new RateReader();

            string currencyRate = args[0];
            double moneyAmount = double.Parse(args[1]);

            string mainCurrency = currencyRate.Substring(0, currencyRate.IndexOf("/"));
            string moneyCurrency = currencyRate.Substring(currencyRate.IndexOf("/"), currencyRate.Length);

            RateConverter rateConverter = new RateConverter(rateReader.CurrencyRates);

            rateConverter.Convert(mainCurrency, moneyCurrency, moneyAmount);
        }
    }
}
