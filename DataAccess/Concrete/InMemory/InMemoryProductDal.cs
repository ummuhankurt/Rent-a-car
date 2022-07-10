using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars; // Bu class için global deiğşken.
        public InMemoryProductDal()
        {
            // Oracle'dan veya Sql'den veya Postgres veya MongoDb'den gleiyormuş gibi...
            _cars = new List<Car>
            {
                new Car{ Id = 1, BrandId = 5,Name = "Audi A5", ColorId = 3, DailyPrice = 350000, ModelYear = 2015},
                new Car{ Id = 2, BrandId = 2,Name = "Opel Corse" ,ColorId = 5, DailyPrice = 100000, ModelYear = 2012},
                new Car{ Id = 3, BrandId = 1, Name = "Fiat Fiorino", ColorId = 3, DailyPrice = 150000, ModelYear = 2010},
                new Car{ Id = 4, BrandId = 7, Name = "Renault Megane", ColorId = 6, DailyPrice = 400000, ModelYear = 2018},
                new Car{ Id = 5, BrandId = 2, Name = "Opel Astra", ColorId = 2, DailyPrice = 350000, ModelYear = 2015}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public Car GetById(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Name = car.Name;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }

        List<CarDetailDto> ICarDal.GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
