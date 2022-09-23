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
using System.Linq.Expressions;
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
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            if(id == 90)
            {
                return new ErrorDataResult<List<CarDetailDto>>("Geçersiz id");
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails(p => p.BrandId == id),"İşlem gerçekleşti");
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails(p => p.ColorId == id), "İşlem gerçekleşti");
        }


        [CacheRemoveAspect("")]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Car car)
        {   

            _carDal.Add(car);
            return new SuccessResult("Added");
        }


        public IDataResult<List<CarDetailDto>> GetProductDetailByBrand(int brandId)
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetProductDetails(c => c.BrandId == brandId), true);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetProductDetalis()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails());
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

        public IDataResult<List<CarDetailDto>> GetDetalisByBrandAndColor(string colorName,string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails(c => c.Brand == brandName && c.Color == colorName));
        }
    }
}
