using System;
using System.Collections.Generic;
using System.IO;

namespace Exchange
{
    public class RateReader
    {
        public List<string> allowedCurrencies => new List<string> {"EUR", "USD", "GBP", "SEK", "NOK", "CHF", "JPY"};

        public string RatesFilePath { get; set; }

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
            CurrencyRates = HardcodedCurrencyRates;
        }


        public RateReader(string ratesFilePath)
        {
            if (!File.Exists(ratesFilePath))
            {
                CurrencyRates = HardcodedCurrencyRates;
                Logging.Log("File was not found, using hardcoded values");
            }
            else
            {
                ReadRatesFromFile(ratesFilePath);
            }
        }

        private void ReadRatesFromFile(string ratesFilePath)
        {
            CurrencyRates = new Dictionary<string, double>();

            using (StreamReader ratesFileReader = File.OpenText(ratesFilePath))
            {
                while (!ratesFileReader.EndOfStream)
                {
                    string rateRecord = ratesFileReader.ReadLine();
                    string[] splittedData = rateRecord.Split('\t');

                    int currencyRateIndex = splittedData.Length - 1;
                    int currencyNameIndex = splittedData.Length - 2;

                    string currencyRateFormatted = splittedData[currencyRateIndex].Replace(',', '.');

                    string currencyName = splittedData[currencyNameIndex];
                    double currencyRate;

                    bool isRateRecordValid = double.TryParse(currencyRateFormatted, out currencyRate) && (allowedCurrencies.IndexOf(currencyName) > -1);
                    if (!isRateRecordValid)
                    { 
                        throw new ArgumentException("Rates file is corrupted");
                    }

                    CurrencyRates.Add(currencyName, currencyRate);
                }
            }
        }
    }
}
