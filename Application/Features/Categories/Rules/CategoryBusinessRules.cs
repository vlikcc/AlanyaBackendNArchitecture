using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameCannotBeDublicated(string categoryName)
        {
            IPaginate<Category> result = await _categoryRepository.GetListAsync(c=>c.CategoryName == categoryName);
            if (result.Items.Any()) throw new BusinessException("Category Name Cannot Be Dublicated.");
        }

        public async Task CategoryShouldExcistWhenRequested(Category request)
        {
            if (request == null) throw new BusinessException("Category does not exist.");
        }
    }
}
