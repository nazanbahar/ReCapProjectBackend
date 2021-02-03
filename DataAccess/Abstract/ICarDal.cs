using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //car list
        List<Car>GetAll();
        //add-update-delete
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        //category filter
        List<Car>GetAllByBrand(int brandId);
        List<Car> GetById(int carId);




    }
}

