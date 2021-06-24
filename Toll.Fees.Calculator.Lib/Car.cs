using System;

namespace Toll.Fees.Calculator.Lib
{
    public class Car : IVehicle
    {
        public string GetVehicleType()
        {
            return "Car";
        }
    }
}