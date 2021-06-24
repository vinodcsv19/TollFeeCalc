using System;
using FluentValidation;
using Toll.Fees.Calculator.Lib;

namespace Toll.Fees.Calculator.Api.Model.RequestDto
{
    public class TollFeeCalculatorRequestDto : IVehicle

    {
        /// <summary>
        /// Name of the city for which toll fee calculated 
        /// </summary>
        /// <example>Gothenburg</example>
        public string TaxCity { get; set; }
        /// <summary>
        /// which types of vehicle for which toll fee calculated 
        /// </summary>
        /// <example>Tractor,Emergency,Diplomat,Foreign,Military</example>
        public string VehicleType { get; set; }
        /// <summary>
        /// date and time when Vehicles passes and for which toll fee calculated 
        /// </summary>
        /// <example>"2021-06-23T08:00:08.462Z"</example>
        public DateTime[] Dates { get; set; }

        public string GetVehicleType()
        {
            return VehicleType;
        }
    }

    /// <summary>
    /// request dto Validator will validate for null and empty  check for field  
    /// </summary>
    public class TaxCalculatorRequestDtoValidator : AbstractValidator<TollFeeCalculatorRequestDto>
    {
        /// <summary>
        /// </summary>
        public TaxCalculatorRequestDtoValidator()
        {

            RuleFor(m => m.TaxCity).NotNull().NotEmpty();

            RuleFor(m => m.TaxCity)
                .Must((ct) => ct.ToUpper() == "GOTHENBURG")
                .When(m => m.TaxCity != null)
                .WithMessage(ms=> $"Tax rule has been not Define for this city - {ms.TaxCity}");
            ;
            RuleFor(m => m.VehicleType).NotNull().NotEmpty();
            RuleFor(m => m.Dates).NotNull().NotEmpty();
 
        }
       
    }
}