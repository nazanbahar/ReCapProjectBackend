using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

/// <summary>
/// 1. bkz. CarDetailDto.cs
/// 2. DB Contex: DatabaseContext olarak değiştirildi...
/// 3. GetCarDetails,  GetAllDetails olarak değiştirildi.
/// 4. GetCarDetailsv2 Deleted code
/// filter is null ?
///  : context.Cars.Where(filter)
///  return result.ToList();
///  IQueryable<CarDetailDto>
///  return  result.ToList();
///  5. DTO Code-master
///  IQueryable<CarListDetailsDto> carDetailsDtos = from car in filter is null ? recapContext.Cars : recapContext.Cars.Where(filter)
/// </summary>
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
      
        
        //ver1.delege: expression
        public List<CarDetailDto> GetAllDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                IQueryable<CarDetailDto> carDetailDtos =
                             from ca in filter == null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                                on ca.BrandId equals br.Id
                             join co in context.Colors
                                on ca.ColorId equals co.Id
                             join ci in context.CarImages
                                on ca.Id equals ci.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandId = br.Id,
                                 ColorId = co.Id,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = ca.CarName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 //images
                                 Images = (from i in context.CarImages where i.CarId == ca.Id select i.ImagePath).ToList(),
                                 //rented
                                 IsRented = !context.Rentals
                                 .Any(re => re.CarId == ca.Id) || !context.Rentals
                                 .Any(re => re.CarId == ca.Id && (re.ReturnDate == null 
                                 || (re.ReturnDate.HasValue && re.ReturnDate > DateTime.Now)))
                             };

                return carDetailDtos.ToList();
            }
        }




        //ver2.
        public List<CarDetailDto> GetAllDetailsv2(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
               
                 var result = from ca in context.Cars 
                          join br in context.Brands
                             on ca.BrandId equals br.Id
                          join co in context.Colors
                             on ca.ColorId equals co.Id
                          join ci in context.CarImages
                             on ca.Id equals ci.Id
                          select new CarDetailDto
                          {
                              Id = ca.Id,
                              BrandId = br.Id,
                              ColorId = co.Id,
                              BrandName = br.BrandName,
                              ColorName = co.ColorName,
                              CarName = ca.CarName,
                              ModelYear = ca.ModelYear,
                              DailyPrice = ca.DailyPrice,
                              Description = ca.Description,
                              //images
                              Images = (from i in context.CarImages where i.CarId == ca.Id select i.ImagePath).ToList(),
                              //rented
                              IsRented = !context.Rentals
                              .Any(re => re.CarId == ca.Id) || !context.Rentals
                              .Any(re => re.CarId == ca.Id && (re.ReturnDate == null
                              || (re.ReturnDate.HasValue && re.ReturnDate > DateTime.Now)))
                          };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }



        //ver3.
        public List<CarDetailDto> GetAllDetailsv3(Expression<Func<Car, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {

                var result = from ca in filter == null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                                on ca.BrandId equals br.Id
                             join co in context.Colors
                                on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 BrandId = br.Id,
                                 ColorId = co.Id,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = ca.CarName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 //images
                                 Images = (from i in context.CarImages where i.CarId == ca.Id select i.ImagePath).ToList(),
                                 //rented
                                 IsRented = !context.Rentals
                                 .Any(re => re.CarId == ca.Id) || !context.Rentals
                                 .Any(re => re.CarId == ca.Id && (re.ReturnDate == null
                                 || (re.ReturnDate.HasValue && re.ReturnDate > DateTime.Now)))
                             };

                return result.ToList();
            }
        }

    }
}

