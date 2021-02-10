using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository <T> where T: class, IEntity, new()
    {
        //expression -data filter
        List<T> GetAll(Expression<Func<T , bool>> filter=null);
        //only one date details filter
        T Get(Expression<Func<T, bool>> filter);
        //add-delete-update
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);


       

    }
}
