using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Car> _cars; // Bu class için global deiğşken.
        public InMemoryProductDal()
        {
            // Oracle'dan veya Sql'den veya Postgres veya MongoDb'den gleiyormuş gibi...
            _cars = new List<Car>
            {
                new Car{ Id = 1, BrandId = 5, ColorId = 3, DailyPrice = 350000, ModelYear = new DateTime(2015) , Description = "Audi A5"},
                new Car{ Id = 2, BrandId = 2, ColorId = 5, DailyPrice = 100000, ModelYear = new DateTime(2012) , Description = "Opel Corse"},
                new Car{ Id = 3, BrandId = 1, ColorId = 3, DailyPrice = 150000, ModelYear = new DateTime(2010) , Description = "Fiat Fiorino"},
                new Car{ Id = 4, BrandId = 7, ColorId = 6, DailyPrice = 400000, ModelYear = new DateTime(2018) , Description = "Renault Megane"},
                new Car{ Id = 5, BrandId = 2, ColorId = 2, DailyPrice = 350000, ModelYear = new DateTime(2015) , Description = "Opel Astra"}
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

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
