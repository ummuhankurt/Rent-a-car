using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
        public List<ImageDetailDto> GetProductDetails(Expression<Func<ImageDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join images in context.CarImages
                             on c.Id equals images.CarId
                             join b in context.Brands on c.BrandId equals b.Id
                             let imagePath = images.ImagePath
                             select new ImageDetailDto
                             {
                                 Id = c.Id , BrandName = b.BrandName, CarId = images.CarId, Name = c.Name,ImagePaths = images.ImagePath
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
