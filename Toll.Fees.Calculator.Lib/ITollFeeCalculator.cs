using System;
using System.Threading.Tasks;

namespace Toll.Fees.Calculator.Lib
{
    public interface ITollFeeCalculator
    {
        Task<int> GetTollFee(IVehicle vehicle, DateTime[] dates);
        Task<bool> IsTollFreeVehicle(IVehicle vehicle);
    }
}