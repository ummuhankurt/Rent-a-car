using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("User added");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("user deleted");
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("user updated");
        }
    }
}
