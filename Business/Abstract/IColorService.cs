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
        public IResult Update(Color color);
        public IResult Delete(Color color);
        public IDataResult<List<Color>> GetAll();
        public IDataResult<Color> GetById(int id);
    }
}
