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
            //ColorTest();
            //UserAdd();
            //CustomerAdd();
            Rental rental = new Rental
            {
                CarId = 2,
                CustomerId = 1,
                RentDate = new DateTime(2022,07,16),
                ReturnDate = new DateTime(2022,07,25)
            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(rental).Message);
        }
        
       
        private static void CustomerAdd()
        {
            Customer customer = new Customer
            {
                UserId = 1,
                CompanyName = "YapıKredi"
            };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);
        }

        private static void UserAdd()
        {
            User user = new User
            {
                FirstName = "Ayşe",
                LastName = "Yeşim",
                Email = "ayseyesim.23@outlook.com",
                Password = "12345"
            };
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user);
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.FirstName);
            }
        }


        private static void CarTest()
        {
            CarManager productManager = new CarManager(new EfCarDal());
            // GetCarsByBrandId
            foreach (var item in productManager.GetCarsByBrandId(5).Data)
            {
                Console.WriteLine(item.Name);
            }
            // bütün ürünler
            foreach (var item in productManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
            // GetCarsByColorId
            foreach (var item in productManager.GetCarsByColorId(5).Data)
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
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var item in carManager.GetProductDetails().Data)
            //{
            //    Console.WriteLine(item.Name + " / " + item.Brand + " / " + item.DailyPrice + " / " + item.Color);
            //}
            Console.WriteLine(carManager.GetCarsByBrandId(90).Message);
        }
    }
}
