using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.UpdateTourList
{
    public class UpdateTourListCommandValidator : AbstractValidator<UpdateTourListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTourListCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(v => v.City).NotEmpty().WithMessage("City is required");
        }
    }
}
