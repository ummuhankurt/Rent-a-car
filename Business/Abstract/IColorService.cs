using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        public IResult Add(Color color);
        public IDataResult<List<Color>> GetAll(); 
    }
}
