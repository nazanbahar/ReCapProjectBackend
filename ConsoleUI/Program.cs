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
            //BrandTest();
            //CarDetailDto();
            CarTest();

        }

         private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.ColorName + "/" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }


        private static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }


        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }






    }
}
