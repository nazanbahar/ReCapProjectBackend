using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //technology
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("getall****************");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine (car.CarId + "" + car.BrandId, "" + car.ColorId, "" + "" + car.ModelYear, +car.DailyPrice, "" + car.CarName + "" + car.Description);
            }

            Console.WriteLine("carid list*********");
            foreach (var car in carManager.GetById())
            {
                Console.WriteLine(car.CarId);
            }
                
 
            Console.WriteLine("GetByDailyPrice'a göre******");
            foreach (var car in carManager.GetByDailyPrice(100, 500))
            {
                Console.WriteLine(car.CarName, car.DailyPrice);

            }

            Console.WriteLine("GetCarsByColorId'ye göre******");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarName, car.Description);

            }

            Console.WriteLine("GetCarsByBrandId'ye göre******");
            foreach (var car in carManager.GetCarsByBrandId(5))
            {
                Console.WriteLine(car.CarName, car.Description);

            }



        }
    }
}
