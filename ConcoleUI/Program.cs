using Business.Concrete;
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
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            Console.WriteLine("Bütün ürünler : ");
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.Description);
            }
            Console.WriteLine("Ürün eklndikten sonra ürünleri listeleme");
            Car car = new Car { Id = 6, BrandId = 8, ColorId = 9, ModelYear = new DateTime(2014), DailyPrice = 178000, Description = "Mini Cooper" };
            productManager.Add(car);
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.Description);
            }
            Console.WriteLine("id si 6 olan ürünün fiyatini 200000 olacak şekilde update ettik");
            var carToUpdate = productManager.GetById(6);
            carToUpdate.DailyPrice = 200000;
            productManager.Update(carToUpdate);
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.Description + " " + product.DailyPrice);
            }
            Console.WriteLine("id si 6 olan productı getirme");
            Console.WriteLine(productManager.GetById(6).Description);
            Console.WriteLine("id si 6 olan ürünü sileim");
            productManager.Delete(productManager.GetById(6));
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.Description);
            }

        }
    }
}
