using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.UpdateTourPackage
{
    public class UpdateTourPackageCommand : IRequest
    {
            
    }

    public class UpdateTourPackageCommandHandler : IRequestHandler<UpdateTourPackageCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTourPackageCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Unit> Handle(UpdateTourPackageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourPackages.FindAsync(request.Id);

            entity.Name = request.Name;
;           await _context.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
