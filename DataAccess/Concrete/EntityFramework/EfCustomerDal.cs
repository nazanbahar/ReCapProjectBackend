using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq; //s1.

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal //s2.
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null) //s3.
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                IQueryable<CustomerDetailDto> customerDetailDtos =
                    from cu in filter is null ? context.Customers : context.Customers.Where(filter)
                    join u in context.Users on cu.UserId
                    equals u.Id
                    select new CustomerDetailDto { 
                        CustomerId = cu.Id,
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

