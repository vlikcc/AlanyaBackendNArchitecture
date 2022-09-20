using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using FluentValidation;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using Application.Features.Categories.Rules;
using Application.Features.Customers.Rules;
using Application.Features.Employees.Rules;

namespace Application.Services
{
    public  static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<CustomerBusinessRules>();
            services.AddScoped<EmployeeBusinessRules>();

            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
