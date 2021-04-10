using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
/// <summary>
/// s1. bkz. RentalDetailDto.cs
/// s2. DB Contex: DatabaseContext olarak değiştirildi...
/// s3. GetRentalDetails,  GetAllDetails olarak değiştirildi.
/// s4. DTO-v1.
///     public List<RentalDetailDto> GetAllDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
///{
///    using (DatabaseContext context = new DatabaseContext())
///    {
///        var result = from re in context.Rentals
///                     join ca in context.Cars on re.CarId equals ca.Id
///                     join br in context.Brands on ca.BrandId equals br.Id
///                     join co in context.Colors on ca.ColorId equals co.Id
///                     join cu in context.Customers on re.CustomerId equals cu.Id
///                     select new RentalDetailDto
///                     {
///                         //re
///                         Id = re.Id,
///                         CarId = ca.Id,
///                         BrandId = ca.BrandId,
///                         ColorId = ca.ColorId,
///                        CustomerId = cu.Id,
///                         UserId = cu.UserId,
///                         RentDate = re.RentDate,
///                         ReturnDate = re.ReturnDate,
///                         //cu
///                         CustomerName = cu.CompanyName,
///                         CompanyName = cu.CompanyName,
///                         //ca
///                         CarName = ca.CarName,
///                         ModelYear = ca.ModelYear,
///                         DailyPrice = ca.DailyPrice,
///                         Description = ca.Description,
///                         IsRented = ca.IsRented,
///                  };
///        return filter == null ? result.ToList() : result.Where(filter).ToList();
///    }
///}
/// </summary>

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                IQueryable<RentalDetailDto> rentalDetailDtos =
                             from re in filter is null ? context.Rentals:
                             context.Rentals.Where(filter)
                             join ca in context.Cars on re.CarId equals ca.Id 
                             join br in context.Brands on ca.BrandId equals br.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             join cu in context.Customers on re.CustomerId equals cu.Id

                             select new RentalDetailDto
                             {
                                 //re
                                 Id = re.Id,
                                 CarId = ca.Id,
                                 BrandId = ca.BrandId,
                                 ColorId = ca.ColorId,
                                 CustomerId = cu.Id,
                                 UserId = cu.UserId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 //cu
                                 CustomerName = cu.CompanyName,
                                 CompanyName = cu.CompanyName,
                                 //ca
                                 CarName = ca.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 IsRented = ca.IsRented,

                             };

                return rentalDetailDtos.ToList(); 
            }
        }

    }
}
