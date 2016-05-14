using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
namespace Account_Info_Upload_Application
{
    public class FileReader
    {
        private static int line = 0;
        public static bool check(String path)
        {
            if (System.IO.File.Exists(path))
            {
                line = 0;
                return true;
            }
                return false;
        }
        public static List<Transaction> read(String filename)
        {
            List<Transaction> list = new List<Transaction>();
            StreamReader reader = new StreamReader(File.OpenRead(@filename));
            while (!reader.EndOfStream)
            {
                line++;
                String currentline = reader.ReadLine();
                String[] parts = currentline.Split(new Char[] { ',', ';', '\t' });
                double doubleValue;
                HashSet<String> currencies = generateAllCurrencies();
                String account = parts[0].Replace(" ", String.Empty);
                String description = parts[1].Replace(" ", String.Empty);
                String currency = parts[2].Replace(" ", String.Empty);
                String value = parts[3].Replace(" ", String.Empty);
                if (parts.Length != 4 || !double.TryParse(value, out doubleValue) 
                    || !currencies.Contains(currency))
                {
                    continue;
                }
                list.Add(new Transaction(account, description, currency, doubleValue));

            }
            return list;
        }
        public static int getLine()
        {
            return line;
        }
        private static HashSet<String> generateAllCurrencies()
        {
            HashSet<String> currencies = new HashSet<String>();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                currencies.Add(new RegionInfo(ci.LCID).ISOCurrencySymbol);
            }
            return currencies;
        }
    }
}