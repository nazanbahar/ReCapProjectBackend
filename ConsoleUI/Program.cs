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
            //CarDetailDto();
            CarTest();
            //RentalTest();
            //switch-case yapısı ekle.-araba ekleme
            
        }
 

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            var result = rentalManager.GetRentalDetails();

            if (result.Success == true)
            {

                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarName + "/" +rental.CompanyName + "/" + 
                        rental.RentDate + "/" + rental.ReturnDate +"/" + rental.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

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


    }
}
