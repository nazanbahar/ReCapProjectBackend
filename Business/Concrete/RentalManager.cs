using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{

    public class RentalManager : IRentalService
    {

        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [ValidationAspect(typeof(RentalValidator))] //s1
        [SecuredOperation("rental.add, admin")] //s2
        public IResult Add(Rental rental)
        {
            //ReturnDate Control
            var result = _rentalDal.Get(c => c.CarId == rental.CarId &&
                        (c.ReturnDate == null || c.ReturnDate > DateTime.Now));
            if (result != null)
            {
                //magic strings
                return new ErrorResult(Messages.RentedCar);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalCar);
        }




        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);

        }




        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }




        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }




        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId),Messages.RentalsListed);
        }





        public IDataResult<List<RentalDetailDto>> GetAllDetails(Expression<Func<Rental, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllDetails(), Messages.RentalsListed);
        }



 
    }
}
