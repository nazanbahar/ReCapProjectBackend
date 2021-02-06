using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            //using
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);   //referansı yakala
                addedEntity.State = EntityState.Added; //eklenecek nesne
                context.SaveChanges(); //ekle

            }
        }

        public void Delete(Brand entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //SingleOrDefault
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //ternay - where
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
