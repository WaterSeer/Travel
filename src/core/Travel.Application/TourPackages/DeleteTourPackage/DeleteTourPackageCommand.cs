using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.DeleteTourPackage
{
    class DeleteTourPackageCommand : IRequest   
    {
        public int Id { get; set; }
    }

    public class DeleteTourPackageCommandHandler : IRequestHandler<DeleteTourPackageCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTourPackageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTourPackageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourPackages.FindAsync(request.Id);

            _context.TourPackages.Remove(entity);
            await _context.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
