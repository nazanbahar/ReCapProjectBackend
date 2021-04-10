using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
/// <summary>
/// v1.List<CustomerDetailDto> GetAllDetails(Expression<Func<Customer, bool>> filter = null);
///v2.List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null);
///List<CustomerDetailDto> GetCustomerDetails();
/// </summary>
namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetAllDetails(Expression<Func<Customer, bool>> filter = null);

    }
}
