using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IResult Add(User user);
        public IResult Delete(User user);
        public IResult Update(User user);
        public IDataResult<List<User>> GetAll();
        public IDataResult<User> Get(int id);

    }
}
