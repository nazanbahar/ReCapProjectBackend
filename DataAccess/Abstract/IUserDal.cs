using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
/// <summary>
/// v1. List<UserDetailDto> GetAllDetails(Expression<Func<User, bool>> filter = null);
///v2.List<UserDetailDto> GetUserDetails(Expression<Func<User, bool>> filter = null);
/// </summary>
namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        

    }
}
