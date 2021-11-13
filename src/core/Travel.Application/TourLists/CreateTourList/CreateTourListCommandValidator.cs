using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.CreateTourList
{
    public class CreateTourListCommandValidator : AbstractValidator<CreateTourListCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateTourListCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(v => v.City).NotEmpty().WithMessage("About is required");
        }

    }
}
