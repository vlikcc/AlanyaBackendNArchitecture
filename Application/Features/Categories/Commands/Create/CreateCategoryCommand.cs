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

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand:IRequest<CreatedCategoryDto>
    {
        public string CategoryName { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _businessRules;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _businessRules = categoryBusinessRules;
            }

            public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category mappedCategory = _mapper.Map<Category>(request);
                await _businessRules.CategoryNameCannotBeDublicated(request.CategoryName);
                Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
                CreatedCategoryDto result = _mapper.Map<CreatedCategoryDto>(createdCategory);
                return result;

            }
        }
    }
}
