using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAddRentalDtoService
    {
        public IResult Add(AddRentalDto addRental);
        public IResult Delete(AddRentalDto addRental);
        public IResult Update(AddRentalDto addRental);
        public IDataResult<List<AddRentalDto>> GetAll();
        public IDataResult<AddRentalDto> Get(int id);
    }
}
