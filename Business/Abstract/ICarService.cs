using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetProductDetalis();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetDetalisByBrandAndColor(string colorName, string brandName);
        //public IDataResult<List<ColorAndBrandDto>> GetDetalisByBrandAndColor(string colorName, string brandName);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> Get(int id);
        //IDataResult<List<CarDetailDto>> GetProductDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        IResult AddTransactionalTest(Car car);
    }
}
