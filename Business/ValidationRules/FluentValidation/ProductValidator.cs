using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Car>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            //RuleFor(c => c.Name).Must(StartsWitA).WithMessage("Arabanın adı A harfi ile başlamalıdır.");
        }

        private bool StartsWitA(string arg)
        {
            if (arg.StartsWith("A"))
            {
                return true;
            }
            return false;
        }
    }
}
