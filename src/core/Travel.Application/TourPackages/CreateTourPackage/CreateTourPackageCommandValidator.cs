using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.CreateTourPackage
{
    public class CreateTourPackageCommandValidator : AbstractValidator<CreateTourPackageCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTourPackageCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required");

        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationtoken)
        {
            return await _context.TourPackages.AddAsync(l => l.Name != name);
        }
    }
}
