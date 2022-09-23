using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAddRentalDal : EfEntityRepositoryBase<AddRentalDto, ReCapContext>, IAddRentalDal
    {

    }
}
