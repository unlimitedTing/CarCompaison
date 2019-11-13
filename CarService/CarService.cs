using System;
using System.Collections.Generic;
using System.Text;
using Car.Data;
using Car.Model;

namespace Car.Service
{
    public class CarService : ICarService
    {
        private readonly IVechilesRepository _vechilesRepository;
        public CarService(IVechilesRepository vechilesRepository)
        {
            _vechilesRepository = vechilesRepository;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vechilesRepository.GetAll();
        }

        public IEnumerable<Vehicle> GetAllOrderByAlphabetized()
        {
            return _vechilesRepository.GetAllOrderByAlphabetized();
        }

        public IEnumerable<Vehicle> GetAllOrderByPrice()
        {
            return _vechilesRepository.GetAllOrderByPrice();
        }

        public Dictionary<int, double> GetAverageMPGByYear()
        {
            return _vechilesRepository.GetAverageMPGByYear();
        }

        public IEnumerable<double> GetFuelConsumptionByDistance(double distance)
        {
            return _vechilesRepository.GetFuelConsumptionByDistance(distance);
        }

        public Vehicle GetNewestVehicles()
        {
            return _vechilesRepository.GetNewestVehicles();
        }

        public Vehicle GetRandomCar()
        {
            return _vechilesRepository.GetRandomCar();
        }

        public Vehicle GetTheBestValue()
        {
            return _vechilesRepository.GetTheBestValue();
        }
    }

    public interface ICarService
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle GetNewestVehicles();
        IEnumerable<Vehicle> GetAllOrderByAlphabetized();
        IEnumerable<Vehicle> GetAllOrderByPrice();
        Vehicle GetTheBestValue();
        IEnumerable<double> GetFuelConsumptionByDistance(double distance);
        Vehicle GetRandomCar();
        Dictionary<int, double> GetAverageMPGByYear();
    }
}
