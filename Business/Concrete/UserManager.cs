using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
///public IDataResult<List<UserDetailDto>> GetUserDetails()
///{
///    if (DateTime.Now.Hour == 22)
///    {
///        return new ErrorDataResult<List<UserDetailDto>>(Messages.MaintenanceTime);
///    }
///    return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
///}
/// </summary>
namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator))] //s1
        //[SecuredOperation("user.add, admin")] //s2 --admin yetkisi add methodunda kaldırıldı! 
        //UYARI: UserManager.cs'de Add metodunun başına admin yetkisi konulduğunda register olurken yetki isteyecektir onun olmaması daha iyi olur...
       //[SecuredOperation("user.add")] //s2 - yetki sorunu çıkar...
        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }




        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }





        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }





        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }





        [CacheAspect]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }





        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
