using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        //IDataResult<List<UserDetailDto>> GetUserDetails();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        //security-authorization--> must take place after authentication.  
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

    }
}
