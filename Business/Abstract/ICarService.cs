using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
/// <summary> L18: Code Refactoring...
/// L18: Changed: GetCarDetailsByCarId |GetCarDetailsByBrandId | GetCarDetailsByColorId| 
/// L18: (x) Don't used: GetAllByCarId(x)|GetAllByBrandId(x)| GetAllByColorId(x)  
/// Entities → GetAll | GetById |  GetCarsByCarId | GetCarsByBrandId | GetCarsByColorId | GetCarsByBrands | GetCarsByColors  
/// ver1. DTOs → GetCarDetails | GetAllByCarId | GetAllByBrandId | GetAllByColorId |GetCarDetailsByColorAndByBrand 
/// ver2. DTOs → GetCarDetails | GetCarDetailsByCarId | GetCarDetailsByBrandId | GetCarDetailsByColorId |GetCarDetailsByColorAndByBrand|GetAllByBrands | GetAllByColors  
/// 1) Entities → GetAll | GetById |  GetAllByBrandId | GetCAllByColorId |
/// 2) DTOs Data Transfer Object → GetAllDetails | GetAllDetailsByCarId | |GetAllDetailsByBrandId | GetAllDetailsByColorId |GetAllDetailsByColorAndByBrand    
/// 3) Code Refactoring- Changed: 
/// GetAllDetailsByCarId → (x) GetAllByCarId 
/// GetAllDetailsByBrandId → (X) GetAllByBrandId
/// GetAllDetailsByColorId → (X) GetAllByColorId
/// GetAllDetailsByColorAndByBrand → brandId + colorId
/// </summary>
/// 



namespace Business.Abstract
{
    public interface ICarService
    {
        //1) Entities →
        IDataResult<List<Car>>GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetAllByBrandId(int brandId); //+
        IDataResult<List<Car>> GetAllByColorId(int colorId);//+
        //2) DTOs Data Transfer Object → 
        IDataResult<List<CarDetailDto>> GetAllDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<CarDetailDto>> GetAllDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetAllDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetAllDetailsByColorId(int colorId);
        //IDataResult<List<CarDetailDto>> GetAllDetailsByBrandIdAndColorId(int brandId, int colorId);
        //3) CURUD Operations
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);

    }

}


