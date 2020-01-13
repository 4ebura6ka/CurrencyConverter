using System;
using System.IO;

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

            string currentDirectory = Directory.GetCurrentDirectory();
            string ratesFilePath = Directory.GetParent(currentDirectory).Parent.ToString() + "/sample1.txt";
            RateReader rateReader = new RateReader(ratesFilePath);

            double moneyAmount;
            if (!double.TryParse(args[1], out moneyAmount))
            {
                throw new ArgumentException("Amount to exchange is invalid");
            }
           
            string currencyCombination = args[0];
            if (currencyCombination.Length < 7)
            {
                throw new ArgumentException("Currency pair is invalid");
            }

            string[] currencies = currencyCombination.Split('/');
            string mainCurrency = currencies[0];
            string moneyCurrency = currencies[1];

            RateConverter rateConverter = new RateConverter(rateReader.CurrencyRates);

            double result = rateConverter.Convert(mainCurrency, moneyCurrency, moneyAmount);

            Logging.Log(result.ToString());
        }
    }
}