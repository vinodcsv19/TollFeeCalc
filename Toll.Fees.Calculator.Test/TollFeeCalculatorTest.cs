using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Toll.Fees.Calculator.Api.Model.RequestDto;
using Toll.Fees.Calculator.Lib;

namespace Toll.Fees.Calculator.Test
{
    [TestClass]
    public class TollFeeCalculatorTest
    {
        private readonly TollFeeCalculator _tollFeeCalculator;

        public TollFeeCalculatorTest()
        {

            _tollFeeCalculator = new TollFeeCalculator();

        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_vehicles")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Exempt_vehicles_Emergency()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "Emergency",
                Dates = new[]
                {
                    new DateTime(2013, 12, 31, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_vehicles")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Exempt_vehicles_Busses()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "Busses",
                Dates = new[]
                {
                    new DateTime(2013, 12, 31, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_vehicles")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Exempt_vehicles_Diplomat()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "Diplomat",
                Dates = new[]
                {
                    new DateTime(2013, 12, 31, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_vehicles")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Exempt_vehicles_Motorcycles()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "Motorcycles",
                Dates = new[]
                {
                    new DateTime(2013, 12, 31, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_vehicles")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Exempt_vehicles_Military()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "Military",
                Dates = new[]
                {
                    new DateTime(2013, 12, 31, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_vehicles")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Exempt_vehicles_Foreign()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "Foreign",
                Dates = new[]
                {
                    new DateTime(2013, 12, 31, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_on_Weekend")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Is_Weekends_Saturday()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 05, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_on_Weekend")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Is_Weekends_Sunday()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 06, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_on_Weekend")]
        public async Task Should_Return_Tax_SEK_8_When_Tax_Date_and_Time_After_0830_and_before_1459()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2021, 06, 22, 10, 00, 20),
                    new DateTime(2021, 06, 22, 10, 00, 20),
                    new DateTime(2021, 06, 22, 10, 00, 20)

                    ,
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_on_Public_Holiday_year2013")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Is_a_PublicHoliday_Year2013()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 06, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        [TestCategory("Toll_Fee_Exempt_on_Public_Holiday_year2013")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Is_a_Day_Before_PublicHoliday_Year2013()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 03, 28, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee Exempt on Public Holiday year2013")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Is_PublicHoliday_Year2013()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 05, 08, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Toll_Fee Exempt on during the month of July year2013")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Is_During_Month_of_July_Year2013()
        {
            for (var i = 1; i <= 31; i++)
            {
                //Arrange
                var testData = new TollFeeCalculatorRequestDto
                {
                    VehicleType = "car",
                    Dates = new[]
                    {
                        new DateTime(2013, 07, i, 6, 10, 20)
                    }
                };
                //Act
                var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

                //Assert
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_8_When_Tax_Date_Time_In_Between_06_00_To_06_29()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 6, 10, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_13_When_Tax_Date_Time_In_Between_06_30_To_06_59()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 6, 59, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(13, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_18_When_Tax_Date_Time_In_Between_07_00_To_07_59()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 7, 59, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_13_When_Tax_Date_Time_In_Between_08_00_To_08_29()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 8, 29, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(13, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_8_When_Tax_Date_Time_In_Between_08_30_To_14_59()
        {
            for (var i = 9; i < 15; i++)
            {
                //Arrange
                var testData = new TollFeeCalculatorRequestDto
                {
                    VehicleType = "car",
                    Dates = new[]
                    {
                        new DateTime(2013, 01, 2, i, 59, 20)
                    }
                };
                //Act
                var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

                //Assert
                Assert.AreEqual(8, result);
            }
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_13_When_Tax_Date_Time_In_Between_15_00_To_15_29()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 15, 25, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(13, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_18_When_Tax_Date_Time_In_Between_15_30_To_16_59()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 15, 35, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_13_When_Tax_Date_Time_In_Between_17_00_To_17_59()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 17, 35, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(13, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_8_When_Tax_Date_Time_In_Between_18_00_To_18_29()
        {
            //Arrange
            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 18, 25, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Time_In_Between_18_30_To_23_59()
        {
            //Arrange
            for (var i = 18; i < 24; i++)
            {
                var testData = new TollFeeCalculatorRequestDto
                {
                    VehicleType = "car",
                    Dates = new[]
                    {
                        new DateTime(2013, 01, 2, i, 31, 20)
                    }
                };
                //Act
                var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

                //Assert
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        [TestCategory("Hours and amounts for toll fee in Gothenburg")]
        public async Task Should_Return_Tax_SEK_0_When_Tax_Date_Time_In_Between_00_00_To_05_59()
        {
            //Arrange
            for (var i = 0; i < 6; i++)
            {
                var testData = new TollFeeCalculatorRequestDto
                {
                    VehicleType = "car",
                    Dates = new[]
                    {
                        new DateTime(2013, 01, 2, i, 31, 20)
                    }
                };
                //Act
                var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

                //Assert
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        [TestCategory("The single charge rule")]
        public async Task Should_Return_Max_Amount_60_SEK_When_Several_Tolling_Stations_Within_60_Minutes()
        {
            //Arrange

            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 6, 05, 20),
                    new DateTime(2013, 01, 2, 6, 30, 20),
                    new DateTime(2013, 01, 2, 7, 00, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        [TestCategory("The maximum amount per day and vehicle is 60 SEK.")]
        public async Task Should_Return_maximum_Amount_per_day_and_vehicle_is_60_SEK_When_Several_Tolling_Stations_Within_a_Day()
        {
            //Arrange

            var testData = new TollFeeCalculatorRequestDto
            {
                VehicleType = "car",
                Dates = new[]
                {
                    new DateTime(2013, 01, 2, 6, 00, 20),
                    new DateTime(2013, 01, 2, 7, 01, 20),
                    new DateTime(2013, 01, 2, 8, 02, 20),
                    new DateTime(2013, 01, 2, 9, 03, 20),
                    new DateTime(2013, 01, 2, 15, 04, 20),
                    new DateTime(2013, 01, 2, 16, 05, 20),
                    new DateTime(2013, 01, 2, 17, 06, 20)
                }
            };
            //Act
            var result = await _tollFeeCalculator.GetTollFee(testData, testData.Dates);

            //Assert
            Assert.AreEqual(60, result);
        }

    }
}
