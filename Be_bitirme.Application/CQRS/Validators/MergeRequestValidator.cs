using Be_bitirme.Application.CQRS.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Validators
{
    public class MergeRequestValidator : AbstractValidator<MergeBasketRequest>
    {
        public MergeRequestValidator()
        {
            {
                RuleFor(u => u.GuestId).NotEmpty().NotNull();
            }
        }
    }
}
