using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        //veritabanın soyut sınıfına erişeceğiz.
        private ICarDal _carDal;

        //constructor
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }




        //1) CRUD Operations
        [ValidationAspect(typeof(CarValidator))] //s1
        [SecuredOperation("car.add, admin")] //s2.
        [CacheRemoveAspect("ICarService.Get")] //s3
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }





        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }




        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }






        //2) Entities 
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour ==03)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }





        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), Messages.CarsListed);
        }





        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.BrandId == brandId));
        }




        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.ColorId == colorId));
        }






        //3) Data Transfer Object  →  DTO's 
        //L18: CarDetailDto
        //Lesson18: added Method →  GetAllByBrandId(int brandId) & GetAllByColorId(int colorId)

        //GetCarDetails
        public IDataResult<List<CarDetailDto>> GetAllDetails(Expression<Func<Car, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDetails(),Messages.CarsListed);
        }



        //carId 
        public IDataResult<List<CarDetailDto>> GetAllDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDetails(c=> c.Id == carId), Messages.CarsListed);
        }



        //brandId
        public IDataResult<List<CarDetailDto>> GetAllDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDetails(c => c.BrandId == brandId), Messages.CarsListed);
        }



 
        //colorId
        public IDataResult<List<CarDetailDto>> GetAllDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDetails(c => c.ColorId == colorId), Messages.CarsListed);
        }




        //4) AddTransactionalTest
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                //must--> code refactoring 
                throw new Exception("Transaction Error");
            }
            Add(car);
            return null;
        }

  
    }

}


