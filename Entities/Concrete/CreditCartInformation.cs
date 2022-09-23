using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCartInformation : IEntity
    {
        public int Id { get; set; }
        public string CreditCartNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Cvv { get; set; }  
    }
}
