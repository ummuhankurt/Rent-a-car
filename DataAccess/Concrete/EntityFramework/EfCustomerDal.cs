using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,ReCapContext> , ICustomerDal
    {
        public List<CustomerDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers join
                             u in context.Users on c.UserId equals u.Id
                             select new CustomerDto { FirstName = u.FirstName, LastName = u.LastName,CompanyName = c.CompanyName};
                return result.ToList();
            }
        }
    }
}
