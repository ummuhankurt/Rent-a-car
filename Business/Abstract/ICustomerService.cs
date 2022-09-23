using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IResult Add(Customer customer);
        public IResult Delete(Customer customer);
        public IResult Update(Customer customer);
        public IDataResult<List<Customer>> GetAll();
        public IDataResult<Customer> GetById(int id);
        public IDataResult<List<CustomerDto>> GetCustomerDetails();

    }
}
