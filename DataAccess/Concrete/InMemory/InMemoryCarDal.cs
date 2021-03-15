using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car {Id=01, BrandId =1, ColorId=1, ModelYear=2015, DailyPrice =199, CarName="Volvo S40", Description="Süper kullanışlı" },
            new Car {Id=02, BrandId =2, ColorId=2, ModelYear=2016, DailyPrice =299, CarName="BMW 5", Description="Fiyat çok uygun"  },
            new Car {Id=03, BrandId =3, ColorId=3, ModelYear=2017, DailyPrice =399, CarName="Mercedes Benz", Description="Uygun koşullarda" },
            new Car {Id=04, BrandId =4, ColorId=4, ModelYear=2018, DailyPrice =499, CarName="Hyundai Accent", Description="Denemeye değer"  },
            new Car {Id=05, BrandId =5, ColorId=5, ModelYear=2019, DailyPrice =599, CarName="Toyota Corolla", Description="Hemen Al" },
            new Car {Id=06, BrandId =6, ColorId=6, ModelYear=2020, DailyPrice =699, CarName="Volkswagen Golf", Description="Çok Pahalı" },
           
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
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            //remove()
            _cars.Remove(carToDelete);

        }

        public void Update(Car car)
        {
            //LINQ - Language Integrated Query
            //Lambda =>
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
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
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
