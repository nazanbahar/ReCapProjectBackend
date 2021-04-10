using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
/// <summary>
/// v1. List<RentalDetailDto> GetAllDetails(Expression<Func<Rental, bool>> filter = null);
///v2. List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null);
///List<RentalDetailDto> GetRentalDetails();
/// </summary>
namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllDetails(Expression<Func<Rental, bool>> filter = null);
       //List<RentalDetailDto> GetRentalDetails();
    }
}
