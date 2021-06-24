using System.Threading.Tasks;
using Toll.Fees.Calculator.Api.Model.RequestDto;
using Toll.Fees.Calculator.Api.Model.ResponseDto;

namespace Toll.Fees.Calculator.Api.Interfaces
{
    public interface ITollFeeCalculatorService
    {
        /// <summary>
        /// interface define with GetTollFee method which will help to call the method using dependency injunction 
        /// </summary>
        /// <param name="tollFeeCalculatorRequestDto"></param>
        /// <returns></returns>
        Task<TollFeeCalculatorResponseDto> GetTollFee(TollFeeCalculatorRequestDto tollFeeCalculatorRequestDto);
    }
}