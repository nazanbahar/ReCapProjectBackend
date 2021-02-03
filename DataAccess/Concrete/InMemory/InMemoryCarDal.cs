using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car {CarId=01, BrandId =1, ColorId=1, ModelYear=2015, DailyPrice =199, CarName="Volvo S40", Description="Süper kullanışlı" },
            new Car {CarId=02, BrandId =2, ColorId=2, ModelYear=2016, DailyPrice =299, CarName="BMW 5", Description="Fiyat çok uygun"  },
            new Car {CarId=03, BrandId =3, ColorId=3, ModelYear=2017, DailyPrice =399, CarName="Mercedes Benz", Description="Uygun koşullarda" },
            new Car {CarId=04, BrandId =4, ColorId=4, ModelYear=2018, DailyPrice =499, CarName="Hyundai Accent", Description="Denemeye değer"  },
            new Car {CarId=05, BrandId =5, ColorId=5, ModelYear=2019, DailyPrice =599, CarName="Toyota Corolla", Description="Hemen Al" },
            new Car {CarId=06, BrandId =6, ColorId=6, ModelYear=2020, DailyPrice =699, CarName="Volkswagen Golf", Description="Çok Pahalı" },
           
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ - Language Integrated Query
            //Lambda =>
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            //remove()
            _cars.Remove(carToDelete);

        }

        public void Update(Car car)
        {
            //LINQ - Language Integrated Query
            //Lambda =>
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            //update
            carToUpdate.CarName = car.CarName;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        public List<Car> GetAllByBrand(int brandId)
        {
            //car list-marka
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }
    }
}
