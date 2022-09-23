using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ImageDetailDto : IEntity,IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ImagePaths { get; set; }
    }
}
