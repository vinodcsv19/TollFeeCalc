using System;
using System.Linq;
using System.Threading.Tasks;
using Toll.Fees.Calculator.Api.Interfaces;
using Toll.Fees.Calculator.Api.Model.RequestDto;
using Toll.Fees.Calculator.Api.Model.ResponseDto;
using Toll.Fees.Calculator.Lib;

namespace Toll.Fees.Calculator.Api.Services
{
    public class TollFeeCalculatorService : ITollFeeCalculatorService
    {
        private readonly ITollFeeCalculator _tollFeeCalculatorService;

        public TollFeeCalculatorService(ITollFeeCalculator tollFeeCalculatorService)
        {
            _tollFeeCalculatorService = tollFeeCalculatorService;
        }


        /// <summary>
        /// call to GetTollFee method which will return TollFeeCalculatorResponseDto with tax value according to Date 
        /// </summary>
        /// <param name="tollFeeCalculatorRequestDto"></param>
        /// <returns></returns>
        public async Task<TollFeeCalculatorResponseDto> GetTollFee(TollFeeCalculatorRequestDto tollFeeCalculatorRequestDto)
        {
            var tollFeeCalculatorResponseDto = new TollFeeCalculatorResponseDto();

            var isTollFreeVehicle = _tollFeeCalculatorService.IsTollFreeVehicle(tollFeeCalculatorRequestDto);
            if (isTollFreeVehicle.Result)
            {
                tollFeeCalculatorResponseDto.StatusCode = 200;
                tollFeeCalculatorResponseDto.Data = new Data
                {
                    IsTollVehicles = false,
                    TotalTollFeeTax = 0,
                    TollFeeBreakup = null
                };

                return tollFeeCalculatorResponseDto;
            }

            var tollDateBreakupList = tollFeeCalculatorRequestDto.Dates.GroupBy(x => DateTime.Parse(x.ToLongDateString())).ToList();
            var tollFeeBreakupList = (from date in tollDateBreakupList
               let tollListDates = tollFeeCalculatorRequestDto.Dates.Where(x => x.Date.Equals(date.Key)).ToArray()
            let tax = _tollFeeCalculatorService.GetTollFee(tollFeeCalculatorRequestDto, tollListDates)
            select new TollFeeBreakup {TollFee = tax.Result, TollFeeDate = date.Key}).ToList();

            tollFeeCalculatorResponseDto.Data = new Data
            {
                IsTollVehicles = true,
                TollFeeBreakup = tollFeeBreakupList
            };
            tollFeeCalculatorResponseDto.StatusCode = 200;
            tollFeeCalculatorResponseDto.Data.TotalTollFeeTax = tollFeeBreakupList.Sum(x => x.TollFee);


            return tollFeeCalculatorResponseDto;
        }
    }
}