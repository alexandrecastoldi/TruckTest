using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckTest.WebApi.Validation;
using TruckTest.Domain.Entities;
using System.Linq;

namespace TruckTest.WebApi.Test
{
    [TestClass]
    public  class TruckValidationTest
    {
        public TruckValidator TruckValidator { get; set; } = new TruckValidator();
        private Truck _truck; 

        [TestInitialize]
        public void Setup()
        {
            _truck = new Truck()
            {
                Id = 1,
                Active = true,
                Model = Domain.Entities.Enum.TruckModel.FH,
                LastUpdate = DateTime.Now,
                YearFactory = 2020,
                YearModel = 2020
            };
        }

        [TestMethod]
        public void Truck_IsValid()
        {
            var result = TruckValidator.Validate(_truck);
            Assert.IsFalse(result.Errors.Any());
        }

        [TestMethod]
        public void Truck_YearFactoryNotValid()
        {
            _truck.Id = 0;
            _truck.YearFactory = 2021;
            _truck.YearModel = 2021;
            var result = TruckValidator.Validate(_truck);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void Truck_YearModelNotVaild()
        {
            _truck.YearModel = 2022;
            var result = TruckValidator.Validate(_truck);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void Truck_YearModelValid()
        {
            _truck.YearModel = 2021;
            var result = TruckValidator.Validate(_truck);
            Assert.IsFalse(result.Errors.Any());
        }


    }
}
