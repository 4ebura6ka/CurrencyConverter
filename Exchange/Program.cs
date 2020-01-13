using System;

namespace Exchange
{
    class MainClass
    { 
        public static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Logging.Log("Usage: Exchange <currency pair> <amount to exchange>");
            }

            double moneyAmount = double.Parse(args[1]);

            string currencyCombination = args[0];
            string[] currencies = currencyCombination.Split('/');
            string mainCurrency = currencies[0];
            string moneyCurrency = currencies[1];

            RateReader rateReader = new RateReader("/Users/serz/Projects/Exchange/Exchange/sample1.txt");

            RateConverter rateConverter = new RateConverter(rateReader.CurrencyRates);

            double result = rateConverter.Convert(mainCurrency, moneyCurrency, moneyAmount);

            Logging.Log (result.ToString());
        }
    }
}
