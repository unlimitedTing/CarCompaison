using System;
using System.Collections.Generic;
using System.Text;
using Car.Model;
using System.Linq;

namespace Car.Data
{
    public class VechilesRepository : IVechilesRepository
    {
        List<Vehicle> cars = new List<Vehicle>
        {
            new Vehicle
            {
                Make = "Honda",
                Model = "CRV",
                Color = "Green",
                Year = 2016,
                Price = 23845,
                TCCRating = 8,
                HwyMPG = 33
            },
            new Vehicle
            {
                Make = "Ford",
                Model = "Escape",
                Color = "Red ",
                Year = 2017,
                Price = 23590  ,
                TCCRating = 7.8,
                HwyMPG = 32
            },
            new Vehicle
            {
                Make = "Hyundai",
                Model = "Sante Fe",
                Color = "Grey",
                Year = 2016,
                Price = 24950,
                TCCRating = 8,
                HwyMPG = 27
            },
            new Vehicle
            {
                Make = "Mazda",
                Model = "CX-5",
                Color = "Red",
                Year = 2017,
                Price = 21795,
                TCCRating = 8,
                HwyMPG = 35
            },
            new Vehicle
            {
                Make = "Subaru",
                Model = "Forester",
                Color = "Blue",
                Year = 2016,
                Price = 22395,
                TCCRating = 8.4,
                HwyMPG = 32
            },
        };

        public IEnumerable<Vehicle> GetAll()
        {
            return cars.ToList();
        }

        public IEnumerable<Vehicle> GetAllOrderByAlphabetized()
        {
            return cars.OrderBy(c => c.Make).ToList();
        }

        public IEnumerable<Vehicle> GetAllOrderByPrice()
        {
            return cars.OrderBy(c => c.Price).ToList();
        }

        public Dictionary<int,double> GetAverageMPGByYear()
        {
            return cars.GroupBy(c => c.Year).Select(v => new
            {
                v.Key,
                V = v.Average(c => c.HwyMPG)
            }

            ).ToDictionary(t => t.Key, t => t.V);
                
                //Select(v => (Year: v.Key, Avg: v.Average(c => c.HwyMPG))).ToList();
        }

        public IEnumerable<double> GetFuelConsumptionByDistance(double distance)
        {
            return cars.Select(c => distance / c.HwyMPG).ToList();
        }

        public Vehicle GetNewestVehicles()
        {
            return cars.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Vehicle GetRandomCar()
        {
            var rand = new Random();
            var car = cars.ElementAt(rand.Next(cars.Count()));
            return car;
        }

        public Vehicle GetTheBestValue()
        {
            return cars.OrderBy(c =>c.Price/ c.TCCRating).FirstOrDefault();
        }
    }

    public interface IVechilesRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle GetNewestVehicles();
        IEnumerable<Vehicle> GetAllOrderByAlphabetized();
        IEnumerable<Vehicle> GetAllOrderByPrice();
        Vehicle GetTheBestValue();
        IEnumerable<double> GetFuelConsumptionByDistance(double distance);
        Vehicle GetRandomCar();
        Dictionary<int,double> GetAverageMPGByYear();

    }
}
