using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheAspect] // Key,value
        [PerformanceAspect(5)] //bu metodun çalışması 5 saniyeyi geçerse beni uyar.
        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true);
        }
            
        public IDataResult<List<Car>> GetCarsByColorId(int id )
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),"işlem gerçekleşti");
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            if(id == 90)
            {
                return new ErrorDataResult<List<Car>>("Geçersiz id");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),"İşlem gerçekleşti");
        }
        [CacheRemoveAspect("")]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Car car)
        {   
            _carDal.Add(car);
            return new SuccessResult("Added");
        }

        public IDataResult<List<CarDetailDto>> GetProductDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetProductDetails(),true);
        }
        [CacheRemoveAspect("IProducService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Deleted");
        }
        [CacheRemoveAspect("IProductService.Get")] //Bellekte, içinde Get olan bütün keyleri silmemesi için sadece Get değil, IProductService.Get yazıyoruz.
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Updated");
        }
        [CacheAspect]
        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
