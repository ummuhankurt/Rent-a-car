using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int id);
        List<Car> GetAll();
    }
}
