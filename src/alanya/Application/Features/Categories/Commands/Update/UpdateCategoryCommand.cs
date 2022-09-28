using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand:IRequest<UpdatedCategoryDto>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand,UpdatedCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules; 
            }

            public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
                await _categoryBusinessRules.CategoryShouldExcistWhenRequested(category);
                Category mappedCategory = _mapper.Map<Category>(category);
                mappedCategory.CategoryName = request.CategoryName;
                await _categoryBusinessRules.CategoryNameCannotBeDublicated(mappedCategory.CategoryName);
                Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
                UpdatedCategoryDto result = _mapper.Map<UpdatedCategoryDto>(updatedCategory);
                return result;
                
            }
        }
    }
}
