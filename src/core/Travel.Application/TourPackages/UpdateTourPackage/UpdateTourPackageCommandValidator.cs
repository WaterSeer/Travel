using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.UpdateTourPackage
{
    public class UpdateTourPackageCommandValidator : AbstractValidator<UpdateTourPackageCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTourPackageCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            RuleFor(v => v.Name).MustAsync(BeUniqueName).WithMessage("The specified name already exists");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken )
        {
            return await _context.TourPackages.AddAsync(l => l.Name != name);
        }

    }
}
