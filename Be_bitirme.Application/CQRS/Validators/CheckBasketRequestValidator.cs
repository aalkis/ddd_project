using Be_bitirme.Application.CQRS.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Validators
{
    public class CheckBasketRequestValidator : AbstractValidator<CheckBasketRequest>
    {
        public CheckBasketRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().When(x => !x.GuestId.HasValue);
            RuleFor(m => m.GuestId).NotEmpty().When(m => !m.UserId.HasValue);
        }
    }
}
