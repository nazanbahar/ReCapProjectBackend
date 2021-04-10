using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq; //s1. manuel added...
/// <summary>
/// s1. bkz. CustomerDetailDto.cs
/// s2. DB Contex: DatabaseContext olarak değiştirildi...
/// s3. GetCustomerDetails,  GetAllDetails olarak değiştirildi.
/// </summary>
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DatabaseContext>, ICustomerDal //s2.
    {
        public List<CustomerDetailDto> GetAllDetails(Expression<Func<Customer, bool>> filter = null) //s3.
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                IQueryable<CustomerDetailDto> customerDetailDtos =
                    from cu in filter is null ? context.Customers : context.Customers.Where(filter)
                    join u in context.Users on cu.UserId
                    equals u.Id
                    select new CustomerDetailDto { 
                        Id = cu.Id,
                        FirstName = u.FirstName,
                        Lastname = u.LastName,
                        Email = u.Email,
                        CompanyName = cu.CompanyName,
                    };
                return customerDetailDtos.ToList();
            }
        }
    }
}

