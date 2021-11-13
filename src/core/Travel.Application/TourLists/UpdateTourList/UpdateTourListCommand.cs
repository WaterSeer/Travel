using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.UpdateTourList
{
    public class UpdateTourListCommand : IRequest
    {
    }

    public class UpdateTourListCommandHandler : IRequestHandler<UpdateTourListCommand>
    {
        private readonly IApplicationDbContext _context;
        
        public UpdateTourListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourLists.FindAsync(request.Id);

            entity.City = request.City;
            await _context.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
