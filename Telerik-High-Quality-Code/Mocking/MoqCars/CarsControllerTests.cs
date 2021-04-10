namespace MoqCars
{
    using System;
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    
    [TestClass]
    public class MoqCars
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public MoqCars()
            : this(new MoqCarsRepository())
        {
        }

        private MoqCars(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCarsControllerWithDefaultConstructor()
        {
            this.controller = new CarsController();
            this.controller.Index();
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = string.Empty,
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = string.Empty,
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void RemovingCarShouldReturnTrue()
        {
            var isRemoved = (bool)this.GetModel(() => this.controller.Remove(4));

            Assert.IsTrue(isRemoved, "Removing car should return true!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingCarShouldThrowExceptionIfCarIsNotInDatabase()
        {
            this.GetModel(() => this.controller.Remove(5));
        }

        [TestMethod]
        public void SeachingByMakeShouldReturnBMWCarsOnly()
        {
            var cars = (List<Car>)this.GetModel(() => this.controller.Search(string.Empty));
            bool isBMW = true;
            foreach (var car in cars)
            {
                if (car.Make != "BMW")
                {
                    isBMW = false;
                    break;
                }
            }

            Assert.IsTrue(isBMW, "Searching by make should return BMW cars only!");
        }

        [TestMethod]
        public void SortedByYearShouldReturnCarsSortedByYearDescending()
        {
            var cars = (List<Car>)this.GetModel(() => this.controller.Sort("year"));
            bool isSortedCorrect = true;
            for (int i = 0; i < cars.Count - 1; i++)
            {
                if (cars[i].Year < cars[i + 1].Year)
                {
                    isSortedCorrect = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrect, "Sorting by year should return cars sorted by year descending!");
        }

        [TestMethod]
        public void SortedByMakeShouldReturnCarsSortedByMake()
        {
            var cars = (List<Car>)this.GetModel(() => this.controller.Sort("make"));
            bool isSortedCorrect = true;
            for (int i = 0; i < cars.Count - 1; i++)
            {
                Console.WriteLine(cars[i].Make);
                if (string.Compare(cars[i].Make, cars[i + 1].Make) == 1)
                {
                    isSortedCorrect = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrect, "Sorting by make should return cars sorted by make!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortedByNotvalidParametarShouldReturnCarsSortedByMake()
        {
            var cars = (List<Car>)this.GetModel(() => this.controller.Sort("default"));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}