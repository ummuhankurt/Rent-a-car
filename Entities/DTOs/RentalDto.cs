﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    class RentalDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
