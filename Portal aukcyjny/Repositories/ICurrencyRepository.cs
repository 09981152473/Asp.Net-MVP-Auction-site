using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Portal_aukcyjny.Repositories
{
    public class ICurrencyRepository
    {
        public decimal CurrencyExchange(decimal amount, string baseCurrency, string newCurrency)
        {
            System.Net.WebClient client = new WebClient();
            string url = string.Format("https://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", baseCurrency.ToUpper(), newCurrency.ToUpper());
            string result = client.DownloadString(url);
            return amount * Convert.ToDecimal(Regex.Split(result, ",")[1], System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}