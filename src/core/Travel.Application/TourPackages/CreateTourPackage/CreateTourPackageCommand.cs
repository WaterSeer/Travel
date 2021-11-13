using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.CreateTourPackage
{
    public  class CreateTourPackageCommand : IRequest<int>
    {
        
    }

    public class  CreateTourPackageCommandHandler : IRequestHandler<CreateTourPackageCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTourPackageCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<int> Handle(CreateTourPackageCommand request, CancellationToken cancellationToken)
        {
            var entity = new TourPackages();
            _context.TourPackages.Add(entity);
            await _context.SaveChangeAsync(cancellationToken);
            return entity.Id;
        }
    }
}
