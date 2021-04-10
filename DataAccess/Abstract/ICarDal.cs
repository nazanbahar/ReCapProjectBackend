using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
/// <summary>
/// v1.list<cardetaildto> getalldetails(expression<func<car, bool>> filter = null);
///v2.list<cardetaildto> getcardetails(expression<func<car, bool>> filter = null);
///v3.list<cardetaildto> getcardetails();
///v4.list<cardetaildto> getcardetails(expression<func<cardetaildto, bool>> filter = null);
/// </summary>
namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllDetails(Expression<Func<Car, bool>> filter = null);
    }
}

