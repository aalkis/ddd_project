using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;


namespace Be_bitirme.Application.CQRS.Handlers
{
    public class CategoryCheckRequestHandler : IRequestHandler<CategoryCheckRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCheckRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> ListByParentId(int parentId, List<Category> categories)
        {

            return categories.Where(c => c.ParentId == parentId).Select(a => new CategoryDto()
            {
                Id = a.CategoryId,
                CategoryName = a.CategoryName,
                subCategories = ListByParentId(a.CategoryId, categories)
            }).ToList();
        }
        

        public async Task<List<CategoryDto>> Handle(CategoryCheckRequest request, CancellationToken cancellationToken)
        {
            
            var list = await _categoryRepository.ListAllAsync();

            List<CategoryDto> resultList = new List<CategoryDto>();

            foreach (var item in list.Where(x => x.ParentId == 0))
            {
                var model = new CategoryDto()
                {
                    Id = item.CategoryId,
                    CategoryName = item.CategoryName,
                    subCategories = ListByParentId(item.CategoryId, list)
                };

                resultList.Add(model);
            }
            
            return resultList;
        }
    }
}

            //var result = list.Where(x=>x.ParentId == 0).Select(a => new CategoryDto()
            //{
            //    Id = a.CategoryId,
            //    CategoryName = a.CategoryName,
            //    subCategories = ListByParentId(a.CategoryId, list)
            //}).ToList();