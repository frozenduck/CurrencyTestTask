using CurrencyTestTask.DTO;
using CurrencyTestTask.Interfaces;
using CurrencyTestTask.Models;

namespace CurrencyTestTask.Services
{
    public class ConversionService : IConversionService
    {
        private static readonly Currency[] Currencies = new[]
{
            new Currency("euro", "Euro", 0.94m),
            new Currency("usd", "US Dollar", 1.00m),
            new Currency("byn", "Belarusian Ruble", 3.30m),
            new Currency("ars", "Argentinian Peso", 351.17m),
        };

        public ResultDto GetConversion(SumDto input)
        {
            if (input is null || input.Summa is null || !input.Summa.Any() || string.IsNullOrEmpty(input.ResultCurrency))
                throw new ArgumentException($"Input parameters not specified");

            var resultCurrencyExchangeRate = Currencies.FirstOrDefault(c => c.CurrencyId == input.ResultCurrency)?.ExchangeRate;
            if (resultCurrencyExchangeRate is null)
                throw new ArgumentException($"ResultCurrency not found");

            decimal inputValInReserveCurrency = 0m;

            foreach (var inputVal in input.Summa)
            {
                var currency = Currencies.FirstOrDefault(c => c.CurrencyId == inputVal.Currency);
                if (currency is null)
                    throw new ArgumentException($"Currency {inputVal.Currency} not found");

                var reserveCurRate = 1 / currency.ExchangeRate;
                inputValInReserveCurrency += inputVal.Value * reserveCurRate;
            }

            return new ResultDto(input.ResultCurrency, Math.Round(inputValInReserveCurrency * resultCurrencyExchangeRate.Value, 2));
        }
    }
}
