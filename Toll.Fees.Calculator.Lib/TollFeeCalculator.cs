using System;
using System.Linq;
using System.Threading.Tasks;

namespace Toll.Fees.Calculator.Lib
{
    public class TollFeeCalculator:ITollFeeCalculator
    {

        /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

        public async Task<int> GetTollFee(IVehicle vehicle, DateTime[] dates)
        {
            if (await IsTollFreeVehicle(vehicle))
                return 0;
            var sortedDates = dates.OrderBy(x => DateTime.Parse(x.ToLongTimeString())).ToList();

            var intervalStart = sortedDates[0];
            var totalFee = 0;
            foreach (DateTime date in sortedDates)
            {
                var nextFee = GetTollFee(date);
                var tempFee = GetTollFee(intervalStart);

                var minutes = date.Subtract(intervalStart).TotalMinutes;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
                intervalStart = date;

            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }

        public async Task<bool> IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null) return false;
            var vehicleType = vehicle.GetVehicleType();
            return vehicleType.Equals(TollFreeVehicles.Motorcycles.ToString(), StringComparison.OrdinalIgnoreCase) ||
                   vehicleType.Equals(TollFreeVehicles.Busses.ToString(), StringComparison.OrdinalIgnoreCase) ||
                   vehicleType.Equals(TollFreeVehicles.Emergency.ToString(), StringComparison.OrdinalIgnoreCase) ||
                   vehicleType.Equals(TollFreeVehicles.Diplomat.ToString(), StringComparison.OrdinalIgnoreCase) ||
                   vehicleType.Equals(TollFreeVehicles.Foreign.ToString(), StringComparison.OrdinalIgnoreCase) ||
                   vehicleType.Equals(TollFreeVehicles.Military.ToString(), StringComparison.OrdinalIgnoreCase) ||
                   vehicleType.Equals(TollFreeVehicles.Tractor.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public int GetTollFee(DateTime date)
        {
            if (IsTollFreeDate(date)) return 0;

            var hour = date.Hour;
            var minute = date.Minute;

            switch (hour)
            {
                case 6 when minute >= 0 && minute <= 29:
                    return 8;
                case 6 when minute >= 30 && minute <= 59:
                    return 13;
                case 7 when minute >= 0 && minute <= 59:
                    return 18;
                case 8 when minute >= 0 && minute <= 29:
                    return 13;
                default:
                {
                    if (hour >= 8 && minute >= 0 && hour <= 14 && minute <= 59) return 8;
                    switch (hour)
                    {
                        case 15 when minute >= 0 && minute <= 29:
                            return 13;
                        case 15 when minute >= 0:
                        case 16 when minute <= 59:
                            return 18;
                        case 17 when minute >= 0 && minute <= 59:
                            return 13;
                        case 18 when minute >= 0 && minute <= 29:
                            return 8;
                        default:
                            return 0;
                    }
                }
            }
        }

        private Boolean IsTollFreeDate(DateTime date)
        {
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }

        public enum TollFreeVehicles
        {
            Motorcycles = 0,
            Tractor = 1,
            Busses = 2,
            Emergency = 3,
            Diplomat = 4,
            Foreign = 5,
            Military = 6
        }
    }
}