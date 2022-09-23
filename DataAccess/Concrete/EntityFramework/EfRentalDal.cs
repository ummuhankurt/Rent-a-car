using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<Rental> GetRentalDetalis(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             join r in context.Rentals
                             on c.UserId equals r.CustomerId    
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join co in context.Colors
                             on car.ColorId equals co.Id
                             join b in context.Brands on
                             car.BrandId equals b.Id
                             select new Rental {Id= car.Id,CustomerId = c.CustomerId ,RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate , BrandName = b.BrandName,CarId = car.Id,ColorName= co.ColorName,
                                 Email = u.Email,FirstName=u.FirstName,LastName=u.LastName,Name=car.Name,ModelYear = car.ModelYear
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
