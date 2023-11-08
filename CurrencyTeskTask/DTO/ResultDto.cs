namespace CurrencyTestTask.DTO
{
    public class ResultDto
    {
        public ResultDto(string resultCurrency, decimal value)
        {
            ResultCurrency = resultCurrency;
            Value = value;
        }

        public string ResultCurrency { get; set; }
        public decimal Value { get; set; }
    }
}