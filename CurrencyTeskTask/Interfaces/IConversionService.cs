using CurrencyTestTask.DTO;

namespace CurrencyTestTask.Interfaces
{
    public interface IConversionService
    {
        public ResultDto GetConversion(SumDto input);
    }
}