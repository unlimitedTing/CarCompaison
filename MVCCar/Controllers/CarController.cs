using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Car.Data;
using Car.Model;
using Car.Service;
using MVCCar.ViewModel;

namespace MVCCar.Controllers
{
    [Route("[controller]")]
    public class CarController : Controller
    {
        
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            
            _carService = carService;
        }
        [Route("/")]
        public ActionResult Index()
        {
            var cars = _carService.GetAllOrderByAlphabetized();
            return View(cars);// sending data to the view
        }

        [HttpGet]
        [Route("newest")]
        public ActionResult GetNewestCar()
        {
            var car = _carService.GetNewestVehicles();
            return View(car);
        }

        [HttpGet]
        [Route("orderbyprice")]
        public ActionResult GetAllOrderByPrice()
        {
            var cars = _carService.GetAllOrderByPrice();
            return View(cars);
        }

        [HttpGet]
        [Route("bestvalue")]
        // To-Do
        public ActionResult GetBestValue()
        {
            var car = _carService.GetTheBestValue();
            ViewBag.value = car.Price / (car.TCCRating * 100);
            return View(car);
        }

        [HttpGet]
        [Route("fuleconsumption/{distance}")]
        public ActionResult GetFuleConsumption(double distance)
        {
            var consumption = _carService.GetFuelConsumptionByDistance(distance).ToList();
            var cars = _carService.GetAll().ToList();
            List<CarFuleConsumptionViewModel> carFuleConsumptionViewModels = new List<CarFuleConsumptionViewModel> { };
            for (int i = 0; i < cars.Count(); i++)
            {
                var car = cars[i];
                carFuleConsumptionViewModels.Add(new CarFuleConsumptionViewModel
                {
                    Make = car.Make,
                    Mode = car.Model,
                    Color = car.Color,
                    Year = car.Year,
                    TccRating = car.TCCRating,
                    MPG = car.HwyMPG,
                    Distance = distance,
                    FuleConsumption = consumption[i]
                });
            }
           
            ViewBag.Distance = distance;
            return View(carFuleConsumptionViewModels);
        }

        [HttpGet]
        [Route("random")]
        public ActionResult GetRandomCar()
        {
            var car = _carService.GetRandomCar();
            return View(car);
        }

        [HttpGet]
        [Route("averagempg")]
        public ActionResult GetAverageMPGByYear(int year)
        {
            var averageMPG = _carService.GetAverageMPGByYear();
            return View(averageMPG);
        }
    }
    }