using Application.Features.Categories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand:IRequest<DeletedCategoryDto>
    {
        public string CategoryName { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryDto>
        {
            private readonly ICategoryRepository _categoryeRepository;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryeRepository, IMapper mapper)
            {
                _categoryeRepository = categoryeRepository;
                _mapper = mapper;
            }

            public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryeRepository.GetAsync(c => c.CategoryName == request.CategoryName);

                Category mappedCategory = _mapper.Map<Category>(category);
                Category deletedCategory = await _categoryeRepository.DeleteAsync(mappedCategory);
                DeletedCategoryDto result = _mapper.Map<DeletedCategoryDto>(deletedCategory);
                return result;

            }
        }
    }
}
