using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.UpdateTourPackageDetail
{
    public class UpdateTourPackageDetail
    {

    }

    public class UpdateTourPackageDetailCommand : IRequest
    {

    }

    public class UpdateTourPackageDetailCommandHandler : IRequestHandler<UpdateTourPackageDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTourPackageDetailCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }        
        
        public async Task<Unit> Handle(UpdateTourPackageDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourPackages.FindAsync(request.Id);

            await _context.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
