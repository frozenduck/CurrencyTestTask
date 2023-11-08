namespace CurrencyTestTask.Models
{
    public class Currency
    {
        public Currency(string currencyId, string name, decimal exchangeRate)
        {
            CurrencyId = currencyId;
            ExchangeRate = exchangeRate;
            Name = name;
        }

        public string CurrencyId { get; set; }

        public string Name { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}