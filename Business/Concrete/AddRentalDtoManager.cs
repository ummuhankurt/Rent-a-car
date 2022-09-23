using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddRentalDtoManager : IAddRentalDtoService
    {
        IAddRentalDal _addRentalDal;

        public AddRentalDtoManager(IAddRentalDal addRentalDal)
        {
            _addRentalDal = addRentalDal;
        }

        public IResult Add(AddRentalDto addRental)
        {
            var result = _addRentalDal.Get(r => r.CarId == addRental.CarId && (r.ReturnDate == null || r.ReturnDate > addRental.RentDate));
            if (result == null)
            {
                _addRentalDal.Add(addRental);
                return new SuccessResult("Araba kiralandı");
            }
            else
            {
                return new ErrorResult("Araba henüz teslim edilmedi ! ");
            }

        }

        public IResult Delete(AddRentalDto addRental)
        {
            _addRentalDal.Delete(addRental);
            return new SuccessResult();
        }

        public IDataResult<AddRentalDto> Get(int id)
        {
            return new SuccessDataResult<AddRentalDto>(_addRentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<AddRentalDto>> GetAll()
        {
            return new SuccessDataResult<List<AddRentalDto>>(_addRentalDal.GetAll());
        }

        public IResult Update(AddRentalDto addRental)
        {
            _addRentalDal.Update(addRental);
            return new SuccessResult();
        }
    }
}
