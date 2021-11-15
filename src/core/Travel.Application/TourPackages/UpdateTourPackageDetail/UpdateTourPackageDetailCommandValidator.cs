using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.UpdateTourPackageDetail
{
    public class UpdateTourPackageDetailCommandValidator : AbstractValidator<UpdateTourPackageDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTourPackageDetailCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;

            RuleFor(v => v.Currency).NotEmpty().WithMessage("Currency is required");
        }

        public async Task<bool> BeUnicName(string name, CancellationToken cancelationToken)
        {
            return await _context.TourPackages.AddAsync(l => l.Name != name);
        }


    }
}
