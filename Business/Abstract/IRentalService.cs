using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        public IResult Add(Rental rental);
        public IResult Delete(Rental rental);
        public IResult Update(Rental rental);
        public IDataResult<List<Rental>> GetAll();
        public IDataResult<Rental> Get(int id);
    }
}
