using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //technology
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("************Car AllList**********");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + car.CarName, "" +car.BrandId, "" + car.ColorId, "" + car.DailyPrice, "" + car.Description);
            }

            Console.WriteLine("************CarId List**********");
            foreach (var car in carManager.GetById())
            {
                Console.WriteLine(car.CarId+  "   " + car.DailyPrice);
            }

        }
    }
}
