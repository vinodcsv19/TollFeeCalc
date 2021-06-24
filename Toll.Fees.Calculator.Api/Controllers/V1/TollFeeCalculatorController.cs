using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using Toll.Fees.Calculator.Api.Interfaces;
using Toll.Fees.Calculator.Api.Model.RequestDto;
using Toll.Fees.Calculator.Api.Model.ResponseDto;

namespace Toll.Fees.Calculator.Api.Controllers.V1
{
    /// <summary>
    ///     This controller is used for providing endpoints to calculate Toll fee  in Gothenburg .
    /// </summary>
    [ApiController]
    public class TollFeeCalculatorController : ControllerBase
    {
        private readonly ITollFeeCalculatorService _tollFeeService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="tollFeeService"> interface to inject the service </param>
        public TollFeeCalculatorController(ITollFeeCalculatorService tollFeeService)
        {
            _tollFeeService = tollFeeService;
        }

        /// <summary>
        /// To Calculate Toll fee in Gothenburg
        /// </summary>
        /// <param name="tollFeeCalculatorRequestDto">request Dto to calculate Tax</param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/tollfeecalculator")]
        [SwaggerOperation("postTollFeeCalculation")]
        [SwaggerResponse(200, "Toll fee calculated successfully", typeof(TollFeeCalculatorResponseDto))]
        public async Task<IActionResult> TollFeeCalculator([FromBody] TollFeeCalculatorRequestDto tollFeeCalculatorRequestDto)
        {
          
            var result = await _tollFeeService.GetTollFee(tollFeeCalculatorRequestDto);
            return Ok(result);
        }
    }
}