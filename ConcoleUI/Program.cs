using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            Console.WriteLine("Car Details ;");

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetProductDetails())
            {
                Console.WriteLine(item.Name + " / " + item.Brand + " / " + item.DailyPrice + " / " + item.Color);
            }

        }

        private static void CarTest()
        {
            CarManager productManager = new CarManager(new EfCarDal());
            // GetCarsByBrandId
            foreach (var item in productManager.GetCarsByBrandId(5))
            {
                Console.WriteLine(item.Name);
            }
            // bütün ürünler
            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }
            // GetCarsByColorId
            foreach (var item in productManager.GetCarsByColorId(5))
            {
                Console.WriteLine(item.Name);
            }
            // Araba isminin minimum 2 karakter olması gerekiyor. Bunu bussiness'te kontrol ettik. Bu nesne veritabanına eklenmez.
            Car car = new Car()
            {
                Name = "a",
                BrandId = 9,
                ColorId = 8,
                DailyPrice = 800000,
                ModelYear = 2018
            };
            // günlük fiyat 0'dan büyük olması gerekiyor. Bunu bussiness'te kontrol ettik. Bu nesne veritabanına eklenmez.
            Car car2 = new Car()
            {
                Name = "Qashqai",
                BrandId = 9,
                ColorId = 8,
                DailyPrice = 0,
                ModelYear = 2018
            };
            productManager.Add(car);
            productManager.Add(car2);
        }
    }
}
