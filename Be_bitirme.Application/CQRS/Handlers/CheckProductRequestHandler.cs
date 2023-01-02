using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Handlers
{
    public class CheckProductRequestHandler : IRequestHandler<CheckProductRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CheckProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(CheckProductRequest request, CancellationToken cancellationToken)
        {
            var dto = new ProductDto();
            if (request.ProductID == null || request.ProductID == 0)
            {
                var product = await _productRepository.SingleProductByUrl((string)request.SmartUrl);
                if (product != null)
                {
                    dto.ProductID = product.ProductID;
                    dto.ProductName = product.ProductName;
                    dto.Price = product.Price;
                    dto.CategoryId = product.CategoryId;
                    dto.Stock = product.Stock;
                    dto.SmartURL = product.SmartUrl;
                }
            }
            else if(request.ProductID != null || request.ProductID != 0 )
            {
                var product = await _productRepository.SingleProductAsync((int)request.ProductID);
                if(product !=null)
                {
                dto.ProductID = product.ProductID;
                dto.ProductName = product.ProductName;
                dto.Price = product.Price;
                dto.CategoryId = product.CategoryId;
                dto.Stock = product.Stock;
                    dto.SmartURL = product.SmartUrl;
                }
            }

            return dto;
        }
    }
}
