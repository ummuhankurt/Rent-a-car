using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCartValidator : AbstractValidator<CreditCartInformation>
    {
        public CreditCartValidator()
        {
            RuleFor(c => c.CreditCartNumber).MinimumLength(16);
            RuleFor(c => c.CreditCartNumber).NotEmpty();
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Cvv).MinimumLength(3);
        }
    }
}
