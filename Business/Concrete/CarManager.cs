using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
            
        public List<Car> GetCarsByColorId(int id )
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public void Add(Car car)
        {
            if(car.Name.Length < 2 )
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
            }
            if(car.DailyPrice <= 0 )
            {
                Console.WriteLine("Arabanın günlük fiyatı 0 dan büyük olmalıdır.");
            }
            _carDal.Add(car);
        }

        public List<CarDetailDto> GetProductDetails()
        {
            return _carDal.GetProductDetails();
        }
    }
}
