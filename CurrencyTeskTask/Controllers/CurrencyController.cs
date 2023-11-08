using CurrencyTestTask.DTO;
using CurrencyTestTask.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyTeskTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly IConversionService _conversionService;


        public CurrencyController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost(Name = "GetCurrencySum")]
        public ResultDto Get(SumDto input)
        {
            var res = _conversionService.GetConversion(input);

            return res;
        }
    }
}