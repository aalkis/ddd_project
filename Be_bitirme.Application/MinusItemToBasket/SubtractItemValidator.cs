using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.SubtractItemToBasket;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.MinusItemToBasket
{
    public class SubtractItemValidator : AbstractValidator<SubtractItemBasketRequest>
    {

            public SubtractItemValidator()
            {
            
            RuleFor(u => u.productId).NotEmpty().NotNull();
            RuleFor(m => m.UserId).NotEmpty().When(m => !m.GuestId.HasValue);
            RuleFor(m => m.GuestId).NotEmpty().When(m => !m.UserId.HasValue);
        }
    }
}
