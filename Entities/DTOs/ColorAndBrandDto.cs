using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ColorAndBrandDto : IEntity,IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public double DailyPrice { get; set; }

    }
}
