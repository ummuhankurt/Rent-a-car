using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCartManager : ICreditCartService
    {
        ICreditCartDal _creditCarDal;

        public CreditCartManager(ICreditCartDal creditCarDal)
        {
            _creditCarDal = creditCarDal;
        }
        [ValidationAspect(typeof(CreditCartValidator))]
        public IResult Add(CreditCartInformation creditCartInformation)
        {
            _creditCarDal.Add(creditCartInformation);
            return new SuccessResult("Ödeme başarılı");
        }

        public IDataResult<List<CreditCartInformation>> GetAll()
        {
            return new SuccessDataResult<List<CreditCartInformation>>(_creditCarDal.GetAll());
        }
    }
}
