using Core.DataAccess;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAddRentalDal : IEntityRepository<AddRentalDto>
    {
    }
}
