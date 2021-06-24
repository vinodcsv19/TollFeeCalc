using System;
using System.Collections.Generic;

namespace Toll.Fees.Calculator.Api.Model.ResponseDto
{
    public class TollFeeCalculatorResponseDto
    {
        public int StatusCode { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public bool IsTollVehicles { get; set; }
        public long TotalTollFeeTax { get; set; }
        public List<TollFeeBreakup> TollFeeBreakup { get; set; }
    }
    public class TollFeeBreakup
    {
        public DateTime TollFeeDate { get; set; }
        public int TollFee { get; set; }
    }
}
