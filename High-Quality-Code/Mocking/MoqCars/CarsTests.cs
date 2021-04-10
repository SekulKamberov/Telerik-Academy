// namespace MoqCars
// {
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.VisualStudio.TestTools.UnitTesting;

// using Cars;
// using Cars.Contracts;
// using Cars.Models;

// using Moq;
// using Cars.Infrastructure;
// using Cars.Controllers;

// [TestClass]
// public class CarsTests
// {
// private static IDatabase Data;
// private static ICarsRepository CarsRepository;
// private static CarsController CarsController;

// [ClassInitialize]
// public static void Setup(TestContext context)
// {
// Data = new Database();
// CarsRepository = new CarsRepository(Data);
// CarsController = new CarsController(CarsRepository);
// }

// [TestInitialize]
// public void TestSetup()
// {
// Data.Cars = new List<Car>
// {
// new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
// new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
// new Car { Id = 3, Make = "Opel", Model = "330d", Year = 2007 },
// new Car { Id = 4, Make = "BMw", Model = "Astra", Year = 2010 },
// };
// }

// [ClassCleanup]
// public static void CleanUp()
// {
// }

// [TestMethod]
// [ExpectedException(typeof(NullReferenceException))]
// public void TestWhenCreateCarsRepositoryWithEmptyConstructorAccessTotalCarsPropertyShouldThrowException()
// {
// var carsRepository = new CarsRepository();
// var count = carsRepository.TotalCars;
// }

// [TestMethod]
// [ExpectedException(typeof(NullReferenceException))]
// public void TestWhenCreateCarsRepositoryWithDatabaseParameterWithNotInitializedListInConstructorAccessTotalCarsPropertyShouldThrowException()
// {
// var data = new Database();
// var carsRepository = new CarsRepository(data);
// var count = carsRepository.TotalCars;
// }

// [TestMethod]
// public void TestCarsRepositoryTotalCarsShouldReturnSameCount()
// {
// var carsRepository = new CarsRepository(Data);
// var databaseCarsCount = Data.Cars.Count;
// var cars = carsRepository.TotalCars;

// Assert.AreEqual(databaseCarsCount, cars, "CarsRepository should return same count cars!");
// }

// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestAddNullCarShouldThrowException()
// {
// Car car = null;
// CarsRepository.Add(car);
// }

// [TestMethod]
// public void TestAddCarShouldBeInDatabase()
// {
// Car car = new Car();
// CarsRepository.Add(car);
// var isCarInDatabase = CarsRepository.All().Contains(car);
// Assert.IsTrue(isCarInDatabase, "Car should be added to database.");
// }

// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestRemoveNullCarShouldThrowException()
// {
// Car car = null;
// CarsRepository.Remove(car);
// }

// [TestMethod]
// public void TestRemoveCarDeleteFromDatabase()
// {
// Car car = new Car();
// CarsRepository.Add(car);
// CarsRepository.Remove(car);
// var isCarInDatabase = CarsRepository.All().Contains(car);
// Assert.IsFalse(isCarInDatabase, "Car should be added to database.");
// }

// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestGetByIdShouldThrowExceptionWhenNotInDatabase()
// {
// CarsRepository.GetById(5);
// }

// [TestMethod]
// public void TestGetByIdShouldReturnCarFromDatabase()
// {
// Car car = CarsRepository.GetById(4);

// Assert.IsNotNull(car, "Should get car from database when existing.");
// }

// [TestMethod]
// public void TestSortedByMakeShouldReturnCorrectlySortedList()
// {
// var sortedCars = CarsRepository.SortedByMake().ToList();
// bool isSortedCorrect = true;
// for (int i = 0; i < sortedCars.Count - 1; i++)
// {
// if (string.Compare(sortedCars[i].Make, sortedCars[i + 1].Make) > 0)
// {
// isSortedCorrect = false;
// break;
// }
// }
// Assert.IsTrue(isSortedCorrect, "Sorting by make should return sorted list by make.");
// }

// [TestMethod]
// public void TestSortedByYearShouldReturnSortedByYearDescending()
// {
// var sortedCars = CarsRepository.SortedByYear().ToList();
// bool isSortedCorrect = true;
// for (int i = 0; i < sortedCars.Count - 1; i++)
// {
// Console.WriteLine(sortedCars[i].Year);
// if (sortedCars[i].Year < sortedCars[i + 1].Year)
// {
// isSortedCorrect = false;
// break;
// }
// }
// Assert.IsTrue(isSortedCorrect, "Sorting by year should return sorted list by year descending.");
// }

// [TestMethod]
// public void TestSearchShouldReturnAllCarsWhenStringIsNull()
// {
// var cars = CarsRepository.Search(null);
// var count = cars.Count;
// Assert.IsTrue(count == 4, "Search by null string should return all cars.");
// }

// [TestMethod]
// public void TestSearchShouldReturnAllCarsWhenStringIsEmpty()
// {
// var cars = CarsRepository.Search(string.Empty);
// var count = cars.Count;
// Assert.IsTrue(count == 4, "Search by empty string should return all cars.");
// }

// [TestMethod]
// public void TestSearchShouldReturnAllCarsWithMakeOrModel()
// {
// var searchedString = "Audi";
// var cars = CarsRepository.Search(searchedString);
// var count = cars.Count;
// var expectedCount = 0;
// foreach (var car in cars)
// {
// if (car.Make == searchedString || car.Model == searchedString)
// {
// expectedCount += 1;
// }
// }
// Assert.AreEqual(expectedCount, count, "Search should return all cars with make or model as searched string");
// }

// [TestMethod]
// public void TestViewModelShouldBeNullIfNullIsPassedToConstructor()
// {
// View view = new View(null);
// Assert.AreSame(null, view.Model);
// }

// [TestMethod]
// public void TestViewShouldKeepModel()
// {
// View view = new View(CarsRepository);
// Assert.AreSame(CarsRepository, view.Model);
// }

// [TestMethod]
// public void TestCreateCarsControllerWithDefaultConstructorShouldCreateCarsControllerWithDefaultCarsRepository()
// {
// var carsController = new CarsController();
// }

// [TestMethod]
// public void TestCarsControllerIndexMethodShouldReturnViewWithModelOfCars()
// {
// IView view = CarsController.Index();
// var isListOfCars = view.Model is List<Car>;
// Assert.IsTrue(isListOfCars, "CarsController Method Index() should return View with model cars!");
// }

// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestCarsControllerAddNullCarShouldThrowException()
// {
// Car car = null;
// CarsController.Add(car);
// }
// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestCarsControllerAddCarWithNullModelShouldThrowException()
// {
// Car car = new Car() { Id = 11, Make = "Make", Model = null, Year = 2014 };
// CarsController.Add(car);
// }
// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestCarsControllerAddCarWithEmptyModelShouldThrowException()
// {
// Car car = new Car() { Id = 11, Make = "Make", Model = string.Empty, Year = 2014 };
// CarsController.Add(car);
// }
// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestCarsControllerAddCarWithNullMakeShouldThrowException()
// {
// Car car = new Car() { Id = 11, Make = null, Model = "Model", Year = 2014 };
// CarsController.Add(car);
// }
// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestCarsControllerAddCarWithEmptyMakeShouldThrowException()
// {
// Car car = new Car() { Id = 11, Make = string.Empty, Model = "Model", Year = 2014 };
// CarsController.Add(car);
// }
// [TestMethod]
// public void TestCarsControllerAddCarShouldReturnViewWithModelOfTheCar()
// {
// Car car = new Car() { Id = 11, Make = "Make", Model = "Model", Year = 2014 };
// IView view = CarsController.Add(car);
// var carFromModel = (view.Model as Car);
// Assert.AreSame(car, carFromModel, "Add car should return view with model of car.");
// }
// [TestMethod]
// [ExpectedException(typeof(ArgumentNullException))]
// public void TestCarsControllerDetailsShouldThrowExceptionWhenCarWithIdIsNotExisting()
// {
// CarsController.Details(1222);
// }
// [TestMethod]
// public void TestCarsControllerDetailsShouldReturnView()
// {
// IView view = CarsController.Details(1);
// Assert.IsTrue(view is View, "Details should return view.");
// }
// [TestMethod]
// public void TestCarsControllerDetailsShouldReturnViewWithModelOfCarWhenCarWithIdIsExisting()
// {
// IView view = CarsController.Details(1);
// var car = view.Model as Car;
// Assert.AreEqual(1, car.Id, "Details should return model of car with same id.");
// }
// [TestMethod]
// public void TestCarsControllerSearchShouldReturnViewWithModelListOfCarsMetThatCondition()
// {
// string condition = "Audi";
// var carsView = CarsController.Search(condition);
// var cars = carsView.Model as List<Car>;
// bool isConditionMet = true;
// foreach (var car in cars)
// {
// Console.WriteLine(car.Model + " " + car.Make);
// if (car.Make != condition && car.Model != condition)
// {
// isConditionMet = false;
// }
// }
// Assert.IsTrue(isConditionMet, "CarsController search should return view with model of cars that meet that condition.");
// }
// [TestMethod]
// [ExpectedException(typeof(ArgumentException))]
// public void TestCarsControllerSortShouldThrowExceptionWhenWhenParametarIsInvalid()
// {
// CarsController.Sort("model");
// }
// [TestMethod]
// public void TestCarsControllerSortShouldReturnCarsSortedByMakeWhenParametarIsMake()
// {
// var carsView = CarsController.Sort("make");
// var cars = carsView.Model as List<Car>;
// bool isSortingCorect = true;
// for (int i = 0; i < cars.Count - 1; i++)
// {
// if (string.Compare(cars[i].Make, cars[i + 1].Make) > 1)
// {
// isSortingCorect = false;
// break;
// }
// }
// Assert.IsTrue(isSortingCorect, "Cars Controller sorting by make should return list of cars corectly sorted by make.");
// }
// [TestMethod]
// public void TestCarsControllerSortShouldReturnCarsSortedByYearDescendingWhenParametarIsYear()
// {
// var carsView = CarsController.Sort("year");
// var cars = carsView.Model as List<Car>;
// bool isSortingCorect = true;
// for (int i = 0; i < cars.Count - 1; i++)
// {
// if (cars[i].Year < cars[i + 1].Year)
// {
// isSortingCorect = false;
// break;
// }
// }
// Assert.IsTrue(isSortingCorect, "Cars Controller sorting by year should return list of cars corectly sorted by year descending.");
// }
// }
// }