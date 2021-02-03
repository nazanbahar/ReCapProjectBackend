using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //veritabanın soyut sınıfına erişeceğiz.
        ICarDal _carDal;
       
        //constructor
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //ürün listesi
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById()
        {
            return _carDal.GetAll();
        }
    }
}
