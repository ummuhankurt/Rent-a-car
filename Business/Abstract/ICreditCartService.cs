using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCartService
    {

        public IResult Add(CreditCartInformation creditCartInformation);
        public IDataResult<List<CreditCartInformation>> GetAll();
    }
}
