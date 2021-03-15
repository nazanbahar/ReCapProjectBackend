using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> FindById(int Id);
        IDataResult<List<CarImage>> GetCarListByCarId(int carId);
        IDataResult<CarImage> Get(CarImage img);
        IResult GetList(List<CarImage> list);
        //IDataResult<List<CarImageDetailDto>> GetCarImageDetails();
        IResult Add(IFormFile image, CarImage img);
        IResult Update(IFormFile image, CarImage img);
        IResult Delete(CarImage img);

    }
}
