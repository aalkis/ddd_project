using Azure.Core;
using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Be_bitirme.Application.AddItemToBasket
{
    public class AddItemBasketRequestValidator : AbstractValidator<AddItemBasketRequest>
    {
        private readonly ApplicationDbContext _context;

        public AddItemBasketRequestValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.productId).NotNull().NotEmpty().WithMessage("Product Id can't be null");
        }

        //RuleFor(x => x.productId).MustAsync(CheckStock).WithMessage("There is not enough stock");
        //private async Task <bool> CheckStock(AddItemBasketRequest request, int productId, CancellationToken cancellationToken)
        //{
        //    var product = await _context.Products.SingleOrDefaultAsync(x => x.ProductID == productId);
        //    var productStock = product.Stock;
        //    if(request.count <= productStock)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
